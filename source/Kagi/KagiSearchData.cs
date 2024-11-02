using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the response data for a
	/// <see cref="KagiSearchResult"/>.
	/// </summary>
	/// <remarks>
	/// Response data is polymorphic and should be either
	/// <see cref="KagiRecordSearchData"/> or
	/// <see cref="KagiRelatedQuerySearchData"/>.
	/// </remarks>
	[JsonPolymorphic(
		TypeDiscriminatorPropertyName = "t")]
	[JsonDerivedType(
		typeof(KagiRecordSearchData),
		(int)KagiSearchDataType.Record)]
	[JsonDerivedType(
		typeof(KagiRelatedQuerySearchData),
		(int)KagiSearchDataType.RelatedQuery)]
	public class KagiSearchData
	{
		/// <summary>
		/// The type for the search output.
		/// </summary>
		[JsonPropertyName(
			"t")]
		public KagiSearchDataType Type { get; init; }
	}
}
