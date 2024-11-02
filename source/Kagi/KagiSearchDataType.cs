using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonNumberEnumConverter<KagiSearchDataType>))]
	public enum KagiSearchDataType
	{
		/// <summary>
		/// 
		/// </summary>
		Record = 0,

		/// <summary>
		/// 
		/// </summary>
		RelatedQuery = 1,
	}
}
