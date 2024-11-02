using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiRecordSearchDataThumbnail
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonInclude]
		[JsonPropertyName(
			"url")]
		private string UrlOrProxyPathFragment { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonIgnore]
		public Uri Url =>
			KagiUrlHelper.IsImageProxyPathFragment(
				UrlOrProxyPathFragment) ?
					KagiUrlHelper.ToImageProxyUrl(
						UrlOrProxyPathFragment) :
					new Uri(
						UrlOrProxyPathFragment);

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"width")]
		public int? Width { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"height")]
		public int? Height { get; init; }
	}
}
