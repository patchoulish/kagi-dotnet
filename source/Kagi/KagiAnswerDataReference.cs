using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiAnswerDataReference
	{
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
			"Snippet")]
		public string Snippet { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
