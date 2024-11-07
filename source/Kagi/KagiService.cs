using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class KagiService :
		IKagiService
	{
		/// <summary>
		/// The base URL for the Kagi API.
		/// </summary>
		private const string DefaultBaseUrlValue =
			"https://kagi.com/api/v0/";

		/// <summary>
		/// Gets the default base URL for a <see cref="KagiService"/>.
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(DefaultBaseUrlValue);

		/// <summary>
		/// The JSON serializer options for serializing and deserializing JSON data.
		/// </summary>
		private static JsonSerializerOptions JsonSerializerOptions { get; } =
			new JsonSerializerOptions()
			{
				DefaultIgnoreCondition =
					JsonIgnoreCondition.WhenWritingNull
			};

		/// <summary>
		/// Creates an instance of HttpClient with the specified base URL and API key.
		/// </summary>
		/// <param name="baseUrl">The base URL for the API.</param>
		/// <param name="apiKey">The API key used for authorization.</param>
		/// <returns>A configured HttpClient instance.</returns>
		private static HttpClient CreateClient(
			Uri baseUrl,
			string apiKey)
		{
			ArgumentNullException
				.ThrowIfNull(
					baseUrl,
					nameof(baseUrl));

			ArgumentException
				.ThrowIfNullOrEmpty(
					apiKey,
					nameof(apiKey));

			var client = new HttpClient();

			// Set the base URL for the client to use.
			client.BaseAddress =
				baseUrl;

			// Set the 'Authorization' header value.
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue(
					"Bot",
					apiKey);

			return client;
		}

		/// <summary>
		/// Processes the HTTP response, deserializing it into a result or throwing an exception if the response contains an error.
		/// </summary>
		/// <typeparam name="TResult">Type of result expected from the response.</typeparam>
		/// <param name="response">The HTTP response message.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the result.</returns>
		/// <exception cref="KagiException">Thrown if the response contains an error.</exception>
		private static async Task<TResult> ProcessResponseAsync<TResult>(
			HttpResponseMessage response,
			CancellationToken cancellationToken = default)
				where TResult : KagiResult
		{
			// Check the status code for the response.
			if (response.StatusCode == HttpStatusCode.OK)
			{
				// Read the successful result from the response body.
				// TODO: Should exception handling here be more robust(?)
				var result =
					await response.Content
						.ReadFromJsonAsync<TResult>(
							JsonSerializerOptions,
							cancellationToken);

				return result;
			}
			else
			{
				// Read the error result from the response body.
				var errorResult =
					await response.Content
						.ReadFromJsonAsync<KagiErrorResult>(
							JsonSerializerOptions,
							cancellationToken);

				throw new KagiException(
					"One or more error(s) occurred while processing the request.",
					errorResult.Errors);
			}
		}

		private readonly HttpClient client;

		/// <summary>
		/// Gets the base URL used by the client.
		/// </summary>
		public Uri BaseUrl =>
			this.client
				.BaseAddress;

		/// <summary>
		/// Gets the authorization header value set on the client.
		/// </summary>
		public AuthenticationHeaderValue AuthorizationHeaderValue =>
			this.client
				.DefaultRequestHeaders
				.Authorization;

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiService"/>
		/// class with the specified API key.
		/// </summary>
		/// <param name="apiKey">The API key for authorizing requests.</param>
		public KagiService(
			string apiKey) :
				this(
					DefaultBaseUrl,
					apiKey)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiService"/>
		/// class with the specified base URL and API key.
		/// </summary>
		/// <param name="baseUrl">The base URL for the API.</param>
		/// <param name="apiKey">The API key for authorizing requests.</param>
		public KagiService(
			Uri baseUrl,
			string apiKey) :
				this(
					CreateClient(
						baseUrl,
						apiKey))
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiService"/>
		/// class with a specified <see cref="HttpClient"/>.
		/// </summary>
		/// <param name="client">The <see cref="HttpClient"/> instance to use.</param>
		public KagiService(
			HttpClient client)
		{
			ArgumentNullException
				.ThrowIfNull(
					client,
					nameof(client));

			this.client = client;
		}

		/// <summary>
		/// Sends a summarization request to Kagi.
		/// </summary>
		/// <param name="options">The options for summarization.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the summarization result.</returns>
		/// <exception cref="KagiException">Thrown if the request fails.</exception>
		public async Task<KagiSummarizeResult> SummarizeAsync(
			KagiSummarizeOptions options,
			CancellationToken cancellationToken = default)
		{
			ArgumentNullException
				.ThrowIfNull(
					options,
					nameof(options));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSummarizeRequestUri(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// Serialize the provided options and POST the request...
			var response =
				await this.client
					.PostAsJsonAsync(
						requestUri,
						options,
						JsonSerializerOptions,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSummarizeResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Sends an answer generation request to Kagi.
		/// </summary>
		/// <param name="options">The options for generating the answer.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the answer result.</returns>
		/// <exception cref="KagiException">Thrown if the request fails.</exception>
		public async Task<KagiAnswerResult> AnswerAsync(
			KagiAnswerOptions options,
			CancellationToken cancellationToken = default)
		{
			ArgumentNullException
				.ThrowIfNull(
					options,
					nameof(options));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateAnswerRequestUri(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// Serialize the provided options and POST the request...
			var response =
				await this.client
					.PostAsJsonAsync(
						requestUri,
						options,
						JsonSerializerOptions,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiAnswerResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Sends a search request to Kagi.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="limit">Limit for the number of results returned.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the search result.</returns>
		/// <exception cref="KagiException">Thrown if the request fails.</exception>
		public async Task<KagiSearchResult> SearchAsync(
			string query,
			int limit,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					query,
					nameof(query));

			ArgumentOutOfRangeException
				.ThrowIfNegativeOrZero(
					limit,
					nameof(limit));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSearchRequestUri(
				query,
				limit,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Sends a web enrichment search request to Kagi.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the search result.</returns>
		/// <exception cref="KagiException">Thrown if the request fails.</exception>
		public async Task<KagiSearchResult> SearchWebEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					query,
					nameof(query));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSearchWebEnrichmentsRequestUri(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Sends a news enrichment search request to Kagi.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
		/// <returns>A task that represents the asynchronous operation, containing the search result.</returns>
		/// <exception cref="KagiException">Thrown if the request fails.</exception>
		public async Task<KagiSearchResult> SearchNewsEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					query,
					nameof(query));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSearchNewsEnrichmentsRequestUri(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Tries to create a URI for the summarize request.
		/// </summary>
		/// <param name="result">The resulting URI, if successful.</param>
		/// <returns>True if the URI was created successfully; otherwise, false.</returns>
		private bool TryCreateSummarizeRequestUri(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"summarize",
					out result);

		/// <summary>
		/// Tries to create a URI for the answer request.
		/// </summary>
		/// <param name="result">The resulting URI, if successful.</param>
		/// <returns>True if the URI was created successfully; otherwise, false.</returns>
		private bool TryCreateAnswerRequestUri(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"fastgpt",
					out result);

		/// <summary>
		/// Tries to create a URI for the search request.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="limit">Limit for the number of results.</param>
		/// <param name="result">The resulting URI, if successful.</param>
		/// <returns>True if the URI was created successfully; otherwise, false.</returns>
		private bool TryCreateSearchRequestUri(
			string query,
			int limit,
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					String.Format(
						CultureInfo.InvariantCulture,
						"search?q={0}&limit={1}",
						Uri.EscapeDataString(
							query),
						limit),
					out result);

		/// <summary>
		/// Tries to create a URI for the web enrichment search request.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="result">The resulting URI, if successful.</param>
		/// <returns>True if the URI was created successfully; otherwise, false.</returns>
		private bool TryCreateSearchWebEnrichmentsRequestUri(
			string query,
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					String.Format(
						CultureInfo.InvariantCulture,
						"enrich/web?q={0}",
						Uri.EscapeDataString(
							query)),
					out result);

		/// <summary>
		/// Tries to create a URI for the news enrichment search request.
		/// </summary>
		/// <param name="query">The search query.</param>
		/// <param name="result">The resulting URI, if successful.</param>
		/// <returns>True if the URI was created successfully; otherwise, false.</returns>
		private bool TryCreateSearchNewsEnrichmentsRequestUri(
			string query,
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					String.Format(
						CultureInfo.InvariantCulture,
						"enrich/news?q={0}",
						Uri.EscapeDataString(
							query)),
					out result);
	}
}
