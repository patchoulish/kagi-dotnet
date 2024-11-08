using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the different kinds of summarization.
	/// </summary>
	[JsonConverter(
		typeof(JsonEnumMemberEnumConverter<KagiSummaryKind>))]
	public enum KagiSummaryKind
	{
		/// <summary>
		/// A paragraph or more of summary prose.
		/// </summary>
		[EnumMember(
			Value = "summary")]
		Summary,

		/// <summary>
		/// A bulleted list of key points.
		/// </summary>
		[EnumMember(
			Value = "takeaway")]
		Takeaway,
	}
}
