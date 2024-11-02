using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// Represents the result of an operation.
	/// </summary>
	public class KagiResult
	{
		/// <summary>
		/// The request metadata for the result.
		/// </summary>
		[JsonPropertyName(
			"meta")]
		public KagiResultMetadata Metadata { get; init; }
	}
}
