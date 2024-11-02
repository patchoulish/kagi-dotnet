using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiAnswerResult :
		KagiResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"data")]
		public KagiAnswerData Data { get; init; }
	}
}
