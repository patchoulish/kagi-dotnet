using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents an error that occured.
	/// </summary>
	public class KagiError
	{
		/// <summary>
		/// The <see cref="KagiErrorCode"/> for the error.
		/// </summary>
		[JsonPropertyName(
			"code")]
		public KagiErrorCode Code { get; init; }

		/// <summary>
		/// The message for the error.
		/// </summary>
		[JsonPropertyName(
			"msg")]
		public string Message { get; init; }

		/// <summary>
		/// The location reference for the error, if any.
		/// </summary>
		[JsonPropertyName(
			"ref")]
		public string LocationReference { get; init; }
	}
}
