using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the types of response data for a
	/// <see cref="KagiSearchResult"/>.
	/// </summary>
	[JsonConverter(
		typeof(JsonNumberEnumConverter<KagiSearchDataType>))]
	public enum KagiSearchDataType
	{
		/// <summary>
		/// A search result.
		/// </summary>
		Record = 0,

		/// <summary>
		/// A collection of related search queries.
		/// </summary>
		RelatedQuery = 1,
	}
}
