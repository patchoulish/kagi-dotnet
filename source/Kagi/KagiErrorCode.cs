using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Enumerates the possible error codes.
	/// </summary>
	[JsonConverter(
		typeof(JsonNumberEnumConverter<KagiErrorCode>))]
	public enum KagiErrorCode
	{
		/// <summary>
		/// Indicates an internal error occurred.
		/// </summary>
		InternalError = 0,

		/// <summary>
		/// Indicates the request was malformed.
		/// </summary>
		MalformedRequest = 1,

		/// <summary>
		/// Indicates the operation was unauthorized.
		/// </summary>
		Unauthorized = 2,

		/// <summary>
		/// Indicates the holder of the API key used
		/// does not have their billing configured correctly.
		/// </summary>
		NoBillingInformation = 100,

		/// <summary>
		/// Indicates the holder of the API key used
		/// does not have sufficient credit for the operation.
		/// </summary>
		InsufficientCredit = 101,

		/// <summary>
		/// Indicates the summarization operation failed.
		/// </summary>
		SummarizeFailed = 200
	}
}
