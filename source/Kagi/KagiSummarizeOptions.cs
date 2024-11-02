using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiSummarizeOptions
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url {  get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"text")]
		public string Text { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"engine")]
		public KagiSummaryEngine Engine { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"summary_type")]
		public KagiSummaryKind Kind { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"target_language")]
		public KagiSummaryLanguage OutputLanguage { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"cache")]
		public bool AllowCaching { get; init; }
	}
}
