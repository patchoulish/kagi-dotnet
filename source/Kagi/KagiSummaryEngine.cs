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
		typeof(JsonEnumMemberEnumConverter<KagiSummaryEngine>))]
	public enum KagiSummaryEngine
	{
		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "cecil")]
		Cecil,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "agnes")]
		Agnes,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "muriel")]
		Muriel,
	}
}
