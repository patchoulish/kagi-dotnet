using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiAnswerData
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
			"references")]
		public ImmutableArray<KagiAnswerDataReference> References { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"tokens")]
		public int TokensProcessed { get; init; }
	}
}
