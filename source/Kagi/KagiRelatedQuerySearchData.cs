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
	public class KagiRelatedQuerySearchData :
		KagiSearchData
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"list")]
		public ImmutableArray<string> RelatedQueries { get; init; }
	}
}
