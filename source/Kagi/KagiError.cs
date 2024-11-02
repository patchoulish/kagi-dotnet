using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiError
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"code")]
		public KagiErrorCode Code { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"msg")]
		public string Message { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"ref")]
		public string LocationReference { get; init; }
	}
}
