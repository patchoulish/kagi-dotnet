using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the supported output languages for summarization.
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<KagiSummaryLanguage>))]
	public enum KagiSummaryLanguage
	{
		/// <summary>
		/// The Bulgarian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"BG")]
		Bulgarian,

		/// <summary>
		/// The Czech language.
		/// </summary>
		[JsonStringEnumMemberName(
			"CS")]
		Czech,

		/// <summary>
		/// The Danish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"DA")]
		Danish,

		/// <summary>
		/// The German language.
		/// </summary>
		[JsonStringEnumMemberName(
			"DE")]
		German,

		/// <summary>
		/// The Greek language.
		/// </summary>
		[JsonStringEnumMemberName(
			"EL")]
		Greek,

		/// <summary>
		/// The English language.
		/// </summary>
		[JsonStringEnumMemberName(
			"EN")]
		English,

		/// <summary>
		/// The Spanish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"ES")]
		Spanish,

		/// <summary>
		/// The Estonian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"ET")]
		Estonian,

		/// <summary>
		/// The Finnish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"FI")]
		Finnish,

		/// <summary>
		/// The French language.
		/// </summary>
		[JsonStringEnumMemberName(
			"FR")]
		French,

		/// <summary>
		/// The Hungarian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"HU")]
		Hungarian,

		/// <summary>
		/// The Indonesian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"ID")]
		Indonesian,

		/// <summary>
		/// The Italian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"IT")]
		Italian,

		/// <summary>
		/// The Japanese language.
		/// </summary>
		[JsonStringEnumMemberName(
			"JA")]
		Japanese,

		/// <summary>
		/// The Korean language.
		/// </summary>
		[JsonStringEnumMemberName(
			"KO")]
		Korean,

		/// <summary>
		/// The Lithuanian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"LT")]
		Lithuanian,

		/// <summary>
		/// The Latvian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"LV")]
		Latvian,

		/// <summary>
		/// The Norwegian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"NB")]
		Norwegian,

		/// <summary>
		/// The Dutch language.
		/// </summary>
		[JsonStringEnumMemberName(
			"NL")]
		Dutch,

		/// <summary>
		/// The Polish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"PL")]
		Polish,

		/// <summary>
		/// The Portuguese language.
		/// </summary>
		[JsonStringEnumMemberName(
			"PT")]
		Portuguese,

		/// <summary>
		/// The Romanian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"RO")]
		Romanian,

		/// <summary>
		/// The Russian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"RU")]
		Russian,

		/// <summary>
		/// The Slovak language.
		/// </summary>
		[JsonStringEnumMemberName(
			"SK")]
		Slovak,

		/// <summary>
		/// The Slovenian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"SL")]
		Slovenian,

		/// <summary>
		/// The Swedish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"SV")]
		Swedish,

		/// <summary>
		/// The Turkish language.
		/// </summary>
		[JsonStringEnumMemberName(
			"TR")]
		Turkish,

		/// <summary>
		/// The Ukrainian language.
		/// </summary>
		[JsonStringEnumMemberName(
			"UK")]
		Ukrainian,

		/// <summary>
		/// The Chinese (simplified) language.
		/// </summary>
		[JsonStringEnumMemberName(
			"ZH")]
		ChineseSimplified,

		/// <summary>
		/// The Chinese (traditional) language.
		/// </summary>
		[JsonStringEnumMemberName(
			"ZH-HANT")]
		ChineseTraditional,
	}
}
