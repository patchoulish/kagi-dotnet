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
	/// Represents a service client for the Kagi API.
	/// </summary>
	public sealed class KagiService :
		IKagiService
	{
		/// <summary>
		/// Gets the default base URL for the Kagi API.
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(
				"https://kagi.com/api/v0/");

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
		/// Creates and returns a new instance of the <see cref="HttpClient"/> class
		/// configured to use the specified base URL and API key.
		/// </summary>
		/// <param name="baseUrl">The base URL for the API.</param>
		/// <param name="apiKey">The API key to use for authentication.</param>
		/// <returns>The <see cref="HttpClient"/> instance.</returns>
		private static HttpClient CreateHttpClient(
			Uri baseUrl,
			string apiKey)
		{
			Guard.NotNull(
				baseUrl,
				nameof(baseUrl));

			Guard.NotNullOrEmpty(
				apiKey,
				nameof(apiKey));

			var httpClient =
				new HttpClient();

			// Set the base URL for the client to use.
			httpClient.BaseAddress =
				baseUrl;

			// Set the 'Authorization' header value.
			httpClient.DefaultRequestHeaders.Add(
				$"Authorization",
				$"Bot {apiKey}");

			return httpClient;
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

		private readonly HttpClient httpClient;

		/// <summary>
		/// Gets the base URL used by the client.
		/// </summary>
		public Uri BaseUrl =>
			this.httpClient
				.BaseAddress;

		/// <summary>
		/// Gets the authorization header value set on the client.
		/// </summary>
		public AuthenticationHeaderValue AuthorizationHeaderValue =>
			this.httpClient
				.DefaultRequestHeaders
				.Authorization;

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiService"/>
		/// class with the specified API key.
		/// </summary>
		/// <param name="apiKey">The API key to use for authentication.</param>
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
		/// <param name="apiKey">The API key to use for authentication.</param>
		public KagiService(
			Uri baseUrl,
			string apiKey) :
				this(
					CreateHttpClient(
						baseUrl,
						apiKey))
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiService"/>
		/// class with the specified <see cref="HttpClient"/> instance.
		/// </summary>
		/// <param name="httpClient">The <see cref="HttpClient"/> instance to use.</param>
		public KagiService(
			HttpClient httpClient)
		{
			Guard.NotNull(
				httpClient,
				nameof(httpClient));

			this.httpClient = httpClient;
		}

		/// <inheritdoc />
		public async Task<KagiSummarizeResult> SummarizeAsync(
			KagiSummarizeOptions options,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNull(
				options,
				nameof(options));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSummarizeUrl(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// Serialize the provided options and POST the request...
			var response =
				await this.httpClient
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

		/// <inheritdoc />
		public async Task<KagiAnswerResult> AnswerAsync(
			KagiAnswerOptions options,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNull(
				options,
				nameof(options));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateAnswerUrl(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// Serialize the provided options and POST the request...
			var response =
				await this.httpClient
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

		/// <inheritdoc />
		public async Task<KagiSearchResult> SearchAsync(
			string query,
			int limit,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNullOrWhiteSpace(
				query,
				nameof(query));

			Guard.NotNegativeOrZero(
				limit,
				nameof(limit));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateSearchUrl(
				query,
				limit,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.httpClient
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <inheritdoc />
		public async Task<KagiSearchResult> GetWebEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNullOrWhiteSpace(
				query,
				nameof(query));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateGetWebEnrichmentsUrl(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.httpClient
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <inheritdoc />
		public async Task<KagiSearchResult> GetNewsEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNullOrWhiteSpace(
				query,
				nameof(query));

			// Attempt to create a valid endpoint URL for the request.
			if (!TryCreateGetNewsEnrichmentsUrl(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			// GET the request...
			var response =
				await this.httpClient
					.GetAsync(
						requestUri,
						cancellationToken);

			// ...then process the response and return the result.
			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// Tries to create a URL for the summarize endpoint.
		/// </summary>
		/// <param name="result">The resulting URL, if successful.</param>
		/// <returns>True if the URL was created successfully; otherwise, false.</returns>
		private bool TryCreateSummarizeUrl(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"summarize",
					out result);

		/// <summary>
		/// Tries to create a URL for the answer endpoint.
		/// </summary>
		/// <param name="result">The resulting URL, if successful.</param>
		/// <returns>True if the URL was created successfully; otherwise, false.</returns>
		private bool TryCreateAnswerUrl(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"fastgpt",
					out result);

		/// <summary>
		/// Tries to create a URL for the search endpoint.
		/// </summary>
		/// <param name="query">The query to search for.</param>
		/// <param name="limit">The maximum number of results to return.</param>
		/// <param name="result">The resulting URL, if successful.</param>
		/// <returns>True if the URL was created successfully; otherwise, false.</returns>
		private bool TryCreateSearchUrl(
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
		/// Tries to create a URL for the web enrichments endpoint.
		/// </summary>
		/// <param name="query">The query to fetch enrichment results for.</param>
		/// <param name="result">The resulting URL, if successful.</param>
		/// <returns>True if the URL was created successfully; otherwise, false.</returns>
		private bool TryCreateGetWebEnrichmentsUrl(
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
		/// Tries to create a URL for the news enrichments endpoint.
		/// </summary>
		/// <param name="query">The query to fetch enrichment results for.</param>
		/// <param name="result">The resulting URL, if successful.</param>
		/// <returns>True if the URL was created successfully; otherwise, false.</returns>
		private bool TryCreateGetNewsEnrichmentsUrl(
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
