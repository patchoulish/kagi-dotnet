using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		private const string KagiHttpClientName =
			"kagi";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		/// <param name="optionsCallback"></param>
		/// <returns></returns>
		public static IHttpClientBuilder AddKagiHttpClient(
			this IServiceCollection services,
			Action<KagiServiceOptions> optionsCallback = default)
		{
			Guard.NotNull(
				services,
				nameof(services));

			var options =
				new KagiServiceOptions();

			return services
				.AddHttpClient<IKagiService, KagiService>(
					KagiHttpClientName,
					(httpClient) =>
					{
						// Configure the base URL for the client.
						httpClient.BaseAddress =
							options.BaseUrl;

						// Configure the default request headers for the client.
						httpClient.DefaultRequestHeaders.Authorization =
							new AuthenticationHeaderValue(
								"Bot",
								options.ApiKey);
					});
		}
	}
}
