using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
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
		/// 
		/// </summary>
		[JsonPropertyName(
			"t")]
		public KagiSearchDataType Type { get; init; }
	}
}
