using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiAnswerOptions
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"query")]
		public string Query { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"cache")]
		public bool AllowCaching { get; init; }
	}
}
