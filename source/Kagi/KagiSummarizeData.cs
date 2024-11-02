using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the response data for a
	/// <see cref="KagiSummarizeResult"/>.
	/// </summary>
	public class KagiSummarizeData
	{
		/// <summary>
		/// The summarize output.
		/// </summary>
		[JsonPropertyName(
			"output")]
		public string Output { get; init; }

		/// <summary>
		/// The number of tokens processed to produce the summarize output.
		/// </summary>
		[JsonPropertyName(
			"tokens")]
		public int TokensProcessed { get; init; }
	}
}
