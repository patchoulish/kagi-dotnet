using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiSummarizeData
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"output")]
		public string Output { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"tokens")]
		public int TokensProcessed { get; init; }
	}
}
