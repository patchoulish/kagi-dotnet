using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the result metadata for an operation.
	/// </summary>
	public class KagiResultMetadata
	{
		/// <summary>
		/// The request ID.
		/// </summary>
		[JsonPropertyName(
			"id")]
		public string RequestId { get; init; }

		/// <summary>
		/// The name of the server node that serviced the request.
		/// </summary>
		[JsonPropertyName(
			"node")]
		public string NodeName { get; init; }

		/// <summary>
		/// The duration the server took to service the request, in milliseconds.
		/// </summary>
		[JsonPropertyName(
			"ms")]
		public int DurationInMilliseconds { get; init; }

		/// <summary>
		/// The remaining API balance after the request was serviced, in U.S. dollars.
		/// </summary>
		[JsonPropertyName(
			"api_balance")]
		public decimal? RemainingApiBalance { get; init; }
	}
}
