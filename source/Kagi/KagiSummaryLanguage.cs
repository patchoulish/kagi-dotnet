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
		typeof(JsonEnumMemberEnumConverter<KagiSummaryLanguage>))]
	public enum KagiSummaryLanguage
	{
		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "BG")]
		Bulgarian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "CS")]
		Czech,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "DA")]
		Danish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "DE")]
		German,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "EL")]
		Greek,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "EN")]
		English,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "ES")]
		Spanish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "ET")]
		Estonian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "FI")]
		Finnish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "FR")]
		French,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "HU")]
		Hungarian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "ID")]
		Indonesian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "IT")]
		Italian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "JA")]
		Japanese,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "KO")]
		Korean,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "LT")]
		Lithuanian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "LV")]
		Latvian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "NB")]
		Norwegian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "NL")]
		Dutch,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "PL")]
		Polish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "PT")]
		Portuguese,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "RO")]
		Romanian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "RU")]
		Russian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "SK")]
		Slovak,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "SL")]
		Slovenian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "SV")]
		Swedish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "TR")]
		Turkish,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "UK")]
		Ukrainian,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "ZH")]
		ChineseSimplified,

		/// <summary>
		/// 
		/// </summary>
		[EnumMember(
			Value = "ZH-HANT")]
		ChineseTraditional,
	}
}
