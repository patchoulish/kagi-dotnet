using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the different kinds of summarization.
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<KagiSummaryKind>))]
	public enum KagiSummaryKind
	{
		/// <summary>
		/// A paragraph or more of summary prose.
		/// </summary>
		[JsonStringEnumMemberName(
			"summary")]
		Summary,

		/// <summary>
		/// A bulleted list of key points.
		/// </summary>
		[JsonStringEnumMemberName(
			"takeaway")]
		Takeaway,
	}
}
