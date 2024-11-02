using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the options for a summarize operation.
	/// </summary>
	public class KagiSummarizeOptions
	{
		/// <summary>
		/// The URL of the document to summarize.
		/// </summary>
		/// <remarks>
		/// Exclusive with <see cref="Text"/>.
		/// </remarks>
		[JsonPropertyName(
			"url")]
		public Uri Url {  get; init; }

		/// <summary>
		/// The text to summarize.
		/// </summary>
		/// <remarks>
		/// Exclusive with <see cref="Url"/>.
		/// </remarks>
		[JsonPropertyName(
			"text")]
		public string Text { get; init; }

		/// <summary>
		/// The <see cref="KagiSummaryEngine"/> to use.
		/// </summary>
		[JsonPropertyName(
			"engine")]
		public KagiSummaryEngine Engine { get; init; }

		/// <summary>
		/// The <see cref="KagiSummaryKind"/> to output.
		/// </summary>
		[JsonPropertyName(
			"summary_type")]
		public KagiSummaryKind Kind { get; init; }

		/// <summary>
		/// The <see cref="KagiSummaryLanguage"/> to output.
		/// </summary>
		/// <remarks>
		/// If no language is specified, the language of the document/text provided
		/// is allowed to influence the summarizer's output. Specifying a language
		/// will add an explicit translation step, to translate the summary to the
		/// desired language.
		/// </remarks>
		[JsonPropertyName(
			"target_language")]
		public KagiSummaryLanguage OutputLanguage { get; init; }

		/// <summary>
		/// Whether to allow cached requests and responses.
		/// </summary>
		[JsonPropertyName(
			"cache")]
		public bool AllowCaching { get; init; }
	}
}
