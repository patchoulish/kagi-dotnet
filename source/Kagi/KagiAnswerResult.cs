using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the result of an answer operation.
	/// </summary>
	public class KagiAnswerResult :
		KagiResult
	{
		/// <summary>
		/// The response data for the result.
		/// </summary>
		[JsonPropertyName(
			"data")]
		public KagiAnswerData Data { get; init; }
	}
}
