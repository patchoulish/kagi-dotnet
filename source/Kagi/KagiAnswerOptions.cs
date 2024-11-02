using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the options for an answer operation.
	/// </summary>
	public class KagiAnswerOptions
	{
		/// <summary>
		/// The query to be answered.
		/// </summary>
		[JsonPropertyName(
			"query")]
		public string Query { get; init; }

		/// <summary>
		/// Whether to allow cached requests and responses.
		/// </summary>
		[JsonPropertyName(
			"cache")]
		public bool AllowCaching { get; init; } =
			true;
	}
}
