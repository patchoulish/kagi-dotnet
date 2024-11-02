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
	public class KagiSearchResult :
		KagiResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"data")]
		public ImmutableArray<KagiSearchData> Data { get; init; }
	}
}
