using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents an image associated with a search record.
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
		/// The image URL.
		/// </summary>
		/// <remarks>
		/// Proxied image URLs are automatically fixed-up using
		/// <see cref="KagiUrlHelper"/>.
		/// </remarks>
		[JsonIgnore]
		public Uri Url =>
			KagiUrlHelper.IsImageProxyPathFragment(
				UrlOrProxyPathFragment) ?
					KagiUrlHelper.ToImageProxyUrl(
						UrlOrProxyPathFragment) :
					new Uri(
						UrlOrProxyPathFragment);

		/// <summary>
		/// The width of the image, if any.
		/// </summary>
		[JsonPropertyName(
			"width")]
		public int? Width { get; init; }

		/// <summary>
		/// The height of the image, if any.
		/// </summary>
		[JsonPropertyName(
			"height")]
		public int? Height { get; init; }
	}
}
