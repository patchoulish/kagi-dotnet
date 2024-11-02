using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the result of a summarize operation.
	/// </summary>
	public class KagiSummarizeResult :
		KagiResult
	{
		/// <summary>
		/// The response data for the result.
		/// </summary>
		[JsonPropertyName(
			"data")]
		public KagiSummarizeData Data { get; init; }
	}
}
