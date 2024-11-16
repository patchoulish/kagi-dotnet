using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Kagi
{
	/// <summary>
	/// Represents a <see cref="DelegatingHandler"/>
	/// that treats responses as having been sent by Kagi.
	/// </summary>
	public sealed class KagiDelegatingHandler :
		DelegatingHandler
	{
		/// <summary>
		/// Creates a new instance of the <see cref="KagiDelegatingHandler"/> class.
		/// </summary>
		public KagiDelegatingHandler() :
			base()
		{ }

		/// <inheritdoc/>
		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			var httpClientResponse =
				default(HttpResponseMessage);

			try
			{
				httpClientResponse =
					await base.SendAsync(
						request,
						cancellationToken);
			}
			catch (Exception ex)
			{
				throw new KagiException(
					"The operation was not successful.",
					ex);
			}

			if (!httpClientResponse.IsSuccessStatusCode)
			{
				// Read the error result from the response body.
				var errorResult =
					await httpClientResponse.Content
						.ReadFromJsonAsync<KagiErrorResult>(
							KagiService.JsonSerializerOptions,
							cancellationToken);

				throw new KagiException(
					"The operation was not successful.",
					default,
					httpClientResponse.StatusCode,
					errorResult.Errors);
			}

			return httpClientResponse;
		}
	}
}
