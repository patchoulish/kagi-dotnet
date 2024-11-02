using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.Serialization;

using Kagi;
using Kagi.Internal;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonEnumMemberEnumConverter<KagiSummaryKind>))]
	public enum KagiSummaryKind
	{
		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "summary")]
		Summary,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "takeaway")]
		Takeaway,
	}
}
