using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiSummarizeResult :
		KagiResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"data")]
		public KagiSummarizeData Data { get; init; }
	}
}
