using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

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
		internal static JsonSerializerOptions JsonSerializerOptions { get; } =
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
				new HttpClient(
					new KagiDelegatingHandler(),
					disposeHandler: true);

			// Set the base URL for the client to use.
			httpClient.BaseAddress =
				baseUrl;

			// Set the 'Authorization' header value.
			httpClient.DefaultRequestHeaders.Add(
				$"Authorization",
				$"Bot {apiKey}");

			return httpClient;
		}

		private readonly HttpClient httpClient;

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

			// Serialize and POST the request...
			var response =
				await this.httpClient
					.PostAsJsonAsync(
						$"summarize",
						options,
						JsonSerializerOptions,
						cancellationToken);

			// ...then deserialize the response and return the result.
			return await response.Content
				.ReadFromJsonAsync<KagiSummarizeResult>(
					JsonSerializerOptions,
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

			// Serialize and POST the request...
			var response =
				await this.httpClient
					.PostAsJsonAsync(
						$"fastgpt",
						options,
						JsonSerializerOptions,
						cancellationToken);

			// ...then deserialize the response and return the result.
			return await response.Content
				.ReadFromJsonAsync<KagiAnswerResult>(
					JsonSerializerOptions,
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

			// GET the request then deserialize the response and return the result.
			return await this.httpClient
				.GetFromJsonAsync<KagiSearchResult>(
					$"search?q={Uri.EscapeDataString(query)}&limit={limit}",
					JsonSerializerOptions,
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

			// GET the request then deserialize the response and return the result.
			return await this.httpClient
				.GetFromJsonAsync<KagiSearchResult>(
					$"enrich/web?q={Uri.EscapeDataString(query)}",
					JsonSerializerOptions,
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

			// GET the request then deserialize the response and return the result.
			return await this.httpClient
				.GetFromJsonAsync<KagiSearchResult>(
					$"enrich/news?q={Uri.EscapeDataString(query)}",
					JsonSerializerOptions,
					cancellationToken);
		}
	}
}
