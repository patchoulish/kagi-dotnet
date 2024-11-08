using System;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Kagi
{
	/// <summary>
	/// Represents the options when registering an instance of the <see cref="KagiService"/>
	/// class with an <see cref="IServiceCollection"/>.
	/// </summary>
	public sealed class KagiServiceOptions
	{
		/// <summary>
		/// Gets or sets the base URL to use.
		/// </summary>
		public Uri BaseUrl { get; set; } =
			KagiService.DefaultBaseUrl;

		/// <summary>
		/// Gets or sets the API key to use.
		/// </summary>
		public string ApiKey { get; set; }
	}
}
