using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <inheritdoc />
	public class KagiRelatedQuerySearchData :
		KagiSearchData
	{
		/// <summary>
		/// A collection of related search queries.
		/// </summary>
		[JsonPropertyName(
			"list")]
		public ImmutableArray<string> RelatedQueries { get; init; }
	}
}
