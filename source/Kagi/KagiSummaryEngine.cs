using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the provided summarization engines.
	/// </summary>
	[JsonConverter(
		typeof(JsonEnumMemberEnumConverter<KagiSummaryEngine>))]
	public enum KagiSummaryEngine
	{
		/// <summary>
		/// Provides a friendly, descriptive, fast summary.
		/// </summary>
		[EnumMember(
			Value = "cecil")]
		Cecil,

		/// <summary>
		/// Provides a formal, technical, analytical summary.
		/// </summary>
		[EnumMember(
			Value = "agnes")]
		Agnes,

		/// <summary>
		/// Provides a best-in-class summary using Kagi's enterprise-grade model.
		/// </summary>
		[EnumMember(
			Value = "muriel")]
		Muriel,
	}
}
