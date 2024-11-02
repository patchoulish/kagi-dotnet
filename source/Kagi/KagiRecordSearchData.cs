using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiRecordSearchData :
		KagiSearchData
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"title")]
		public string Title { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"snippet")]
		public string Snippet { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"published")]
		public DateTime? PublicationDate { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"thumbnail")]
		public KagiRecordSearchDataThumbnail Thumbnail { get; init; }
	}
}
