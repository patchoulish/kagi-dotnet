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
	public class KagiErrorResult :
		KagiResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"error")]
		public ImmutableArray<KagiError> Errors { get; init; }
	}
}
