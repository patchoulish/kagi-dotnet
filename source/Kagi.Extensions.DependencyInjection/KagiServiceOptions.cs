using System;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class KagiServiceOptions
	{
		/// <summary>
		/// 
		/// </summary>
		public Uri BaseUrl { get; set; } =
			KagiService.DefaultBaseUrl;

		/// <summary>
		/// 
		/// </summary>
		public string ApiKey { get; set; }
	}
}
