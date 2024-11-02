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
		/// 
		/// </summary>
		InternalError = 0,

		/// <summary>
		/// 
		/// </summary>
		MalformedRequest = 1,

		/// <summary>
		/// 
		/// </summary>
		Unauthorized = 2,

		/// <summary>
		/// 
		/// </summary>
		NoBillingInformation = 100,

		/// <summary>
		/// 
		/// </summary>
		InsufficientCredit = 101,

		/// <summary>
		/// 
		/// </summary>
		SummarizeFailed = 200
	}
}
