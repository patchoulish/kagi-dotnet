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
	public sealed class KagiClient :
		IDisposable
	{
		/// <summary>
		/// 
		/// </summary>
		private const string DefaultBaseUrlValue =
			"https://kagi.com/api/v0/";

		/// <summary>
		/// 
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(DefaultBaseUrlValue);

		/// <summary>
		/// 
		/// </summary>
		private static JsonSerializerOptions JsonSerializerOptions { get; } =
			new JsonSerializerOptions()
			{
				DefaultIgnoreCondition =
					JsonIgnoreCondition.WhenWritingNull
			};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		/// <returns></returns>
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

			client.BaseAddress =
				baseUrl;
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue(
					"Bot",
					apiKey);

			return client;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="response"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
		private static async Task<TResult> ProcessResponseAsync<TResult>(
			HttpResponseMessage response,
			CancellationToken cancellationToken = default)
				where TResult : KagiResult
		{
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result =
					await response.Content
						.ReadFromJsonAsync<TResult>(
							JsonSerializerOptions,
							cancellationToken);

				return result;
			}
			else
			{
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
		private readonly bool ownsClient;
		private volatile bool isDisposed;

		/// <summary>
		/// 
		/// </summary>
		public Uri BaseUrl
		{
			get
			{
				ObjectDisposedException
					.ThrowIf(
						this.isDisposed,
						this);

				return this.client
					.BaseAddress;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public AuthenticationHeaderValue AuthorizationHeaderValue
		{
			get
			{
				ObjectDisposedException
					.ThrowIf(
						this.isDisposed,
						this);

				return this.client
					.DefaultRequestHeaders
					.Authorization;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiKey"></param>
		public KagiClient(
			string apiKey) :
				this(
					DefaultBaseUrl,
					apiKey)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		public KagiClient(
			Uri baseUrl,
			string apiKey) :
				this(
					CreateClient(
						baseUrl,
						apiKey),
					true)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		/// <param name="ownsClient"></param>
		public KagiClient(
			HttpClient client,
			bool ownsClient = false)
		{
			ArgumentNullException
				.ThrowIfNull(
					client,
					nameof(client));

			this.client = client;
			this.ownsClient = ownsClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
		public async Task<KagiSummarizeResult> SummarizeAsync(
			KagiSummarizeOptions options,
			CancellationToken cancellationToken = default)
		{
			ArgumentNullException
				.ThrowIfNull(
					options,
					nameof(options));

			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			if (!TryCreateSummarizeRequestUri(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.client
					.PostAsJsonAsync(
						requestUri,
						options,
						JsonSerializerOptions,
						cancellationToken);

			return await ProcessResponseAsync<KagiSummarizeResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
		public async Task<KagiAnswerResult> AnswerAsync(
			KagiAnswerOptions options,
			CancellationToken cancellationToken = default)
		{
			ArgumentNullException
				.ThrowIfNull(
					options,
					nameof(options));

			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			if (!TryCreateAnswerRequestUri(
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.client
					.PostAsJsonAsync(
						requestUri,
						options,
						JsonSerializerOptions,
						cancellationToken);

			return await ProcessResponseAsync<KagiAnswerResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="limit"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
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

			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			if (!TryCreateSearchRequestUri(
				query,
				limit,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
		public async Task<KagiSearchResult> SearchWebEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					query,
					nameof(query));

			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			if (!TryCreateSearchWebEnrichmentsRequestUri(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="KagiException"></exception>
		public async Task<KagiSearchResult> SearchNewsEnrichmentsAsync(
			string query,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					query,
					nameof(query));

			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			if (!TryCreateSearchNewsEnrichmentsRequestUri(
				query,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.client
					.GetAsync(
						requestUri,
						cancellationToken);

			return await ProcessResponseAsync<KagiSearchResult>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			ObjectDisposedException
				.ThrowIf(
					this.isDisposed,
					this);

			Dispose(
				true);

			this.isDisposed = true;
			GC.SuppressFinalize(
				this);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		private bool TryCreateSummarizeRequestUri(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"summarize",
					out result);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		private bool TryCreateAnswerRequestUri(
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					"fastgpt",
					out result);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="limit"></param>
		/// <param name="result"></param>
		/// <returns></returns>
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
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="result"></param>
		/// <returns></returns>
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
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="result"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		private void Dispose(
			bool disposing)
		{
			if (this.ownsClient)
			{
				this.client?
					.Dispose();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		~KagiClient()
		{
			Dispose(
				false);
		}
	}
}
