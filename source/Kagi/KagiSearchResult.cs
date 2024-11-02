using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents the result of a search operation.
	/// </summary>
	public class KagiSearchResult :
		KagiResult
	{
		/// <summary>
		/// The response data for the result.
		/// </summary>
		[JsonPropertyName(
			"data")]
		public ImmutableArray<KagiSearchData> Data { get; init; }
	}
}
