using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents a search record that was utilized to produce the output for an answer.
	/// </summary>
	public class KagiAnswerDataReference
	{
		/// <summary>
		/// The title of the referenced search record.
		/// </summary>
		[JsonPropertyName(
			"title")]
		public string Title { get; init; }

		/// <summary>
		/// The snippet of the referenced search record, if any.
		/// </summary>
		[JsonPropertyName(
			"Snippet")]
		public string Snippet { get; init; }

		/// <summary>
		/// The URL of the referenced search record.
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
