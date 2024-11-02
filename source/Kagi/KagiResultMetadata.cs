using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiResultMetadata
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"id")]
		public string RequestId { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"node")]
		public string NodeName { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"ms")]
		public int DurationInMilliseconds { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"api_balance")]
		public decimal RemainingApiBalance { get; init; }
	}
}
