using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the provided summarization engines.
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<KagiSummaryEngine>))]
	public enum KagiSummaryEngine
	{
		/// <summary>
		/// Provides a friendly, descriptive, fast summary.
		/// </summary>
		[JsonStringEnumMemberName(
			"cecil")]
		Cecil,

		/// <summary>
		/// Provides a formal, technical, analytical summary.
		/// </summary>
		[JsonStringEnumMemberName(
			"agnes")]
		Agnes,

		/// <summary>
		/// Provides a best-in-class summary using Kagi's enterprise-grade model.
		/// </summary>
		[JsonStringEnumMemberName(
			"muriel")]
		Muriel,
	}
}
