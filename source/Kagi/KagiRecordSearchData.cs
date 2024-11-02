using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <inheritdoc />
	public class KagiRecordSearchData :
		KagiSearchData
	{
		/// <summary>
		/// The URL for the search record.
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }

		/// <summary>
		/// The title for the search record.
		/// </summary>
		[JsonPropertyName(
			"title")]
		public string Title { get; init; }

		/// <summary>
		/// The snippet for the search record, if any.
		/// </summary>
		[JsonPropertyName(
			"snippet")]
		public string Snippet { get; init; }

		/// <summary>
		/// The publication date for the search record, if any.
		/// </summary>
		[JsonPropertyName(
			"published")]
		public DateTime? PublicationDate { get; init; }

		/// <summary>
		/// The image associated with the search record, if any.
		/// </summary>
		[JsonPropertyName(
			"thumbnail")]
		public KagiRecordSearchDataThumbnail Thumbnail { get; init; }
	}
}
