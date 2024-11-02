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
	/// Enumerates the supported output languages for summarization.
	/// </summary>
	[JsonConverter(
		typeof(JsonEnumMemberEnumConverter<KagiSummaryLanguage>))]
	public enum KagiSummaryLanguage
	{
		/// <summary>
		/// The Bulgarian language.
		/// </summary>
		[EnumMember(
			Value = "BG")]
		Bulgarian,

		/// <summary>
		/// The Czech language.
		/// </summary>
		[EnumMember(
			Value = "CS")]
		Czech,

		/// <summary>
		/// The Danish language.
		/// </summary>
		[EnumMember(
			Value = "DA")]
		Danish,

		/// <summary>
		/// The German language.
		/// </summary>
		[EnumMember(
			Value = "DE")]
		German,

		/// <summary>
		/// The Greek language.
		/// </summary>
		[EnumMember(
			Value = "EL")]
		Greek,

		/// <summary>
		/// The English language.
		/// </summary>
		[EnumMember(
			Value = "EN")]
		English,

		/// <summary>
		/// The Spanish language.
		/// </summary>
		[EnumMember(
			Value = "ES")]
		Spanish,

		/// <summary>
		/// The Estonian language.
		/// </summary>
		[EnumMember(
			Value = "ET")]
		Estonian,

		/// <summary>
		/// The Finnish language.
		/// </summary>
		[EnumMember(
			Value = "FI")]
		Finnish,

		/// <summary>
		/// The French language.
		/// </summary>
		[EnumMember(
			Value = "FR")]
		French,

		/// <summary>
		/// The Hungarian language.
		/// </summary>
		[EnumMember(
			Value = "HU")]
		Hungarian,

		/// <summary>
		/// The Indonesian language.
		/// </summary>
		[EnumMember(
			Value = "ID")]
		Indonesian,

		/// <summary>
		/// The Italian language.
		/// </summary>
		[EnumMember(
			Value = "IT")]
		Italian,

		/// <summary>
		/// The Japanese language.
		/// </summary>
		[EnumMember(
			Value = "JA")]
		Japanese,

		/// <summary>
		/// The Korean language.
		/// </summary>
		[EnumMember(
			Value = "KO")]
		Korean,

		/// <summary>
		/// The Lithuanian language.
		/// </summary>
		[EnumMember(
			Value = "LT")]
		Lithuanian,

		/// <summary>
		/// The Latvian language.
		/// </summary>
		[EnumMember(
			Value = "LV")]
		Latvian,

		/// <summary>
		/// The Norwegian language.
		/// </summary>
		[EnumMember(
			Value = "NB")]
		Norwegian,

		/// <summary>
		/// The Dutch language.
		/// </summary>
		[EnumMember(
			Value = "NL")]
		Dutch,

		/// <summary>
		/// The Polish language.
		/// </summary>
		[EnumMember(
			Value = "PL")]
		Polish,

		/// <summary>
		/// The Portuguese language.
		/// </summary>
		[EnumMember(
			Value = "PT")]
		Portuguese,

		/// <summary>
		/// The Romanian language.
		/// </summary>
		[EnumMember(
			Value = "RO")]
		Romanian,

		/// <summary>
		/// The Russian language.
		/// </summary>
		[EnumMember(
			Value = "RU")]
		Russian,

		/// <summary>
		/// The Slovak language.
		/// </summary>
		[EnumMember(
			Value = "SK")]
		Slovak,

		/// <summary>
		/// The Slovenian language.
		/// </summary>
		[EnumMember(
			Value = "SL")]
		Slovenian,

		/// <summary>
		/// The Swedish language.
		/// </summary>
		[EnumMember(
			Value = "SV")]
		Swedish,

		/// <summary>
		/// The Turkish language.
		/// </summary>
		[EnumMember(
			Value = "TR")]
		Turkish,

		/// <summary>
		/// The Ukrainian language.
		/// </summary>
		[EnumMember(
			Value = "UK")]
		Ukrainian,

		/// <summary>
		/// The Chinese (simplified) language.
		/// </summary>
		[EnumMember(
			Value = "ZH")]
		ChineseSimplified,

		/// <summary>
		/// The Chinese (traditional) language.
		/// </summary>
		[EnumMember(
			Value = "ZH-HANT")]
		ChineseTraditional,
	}
}
