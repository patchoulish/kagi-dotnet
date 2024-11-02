using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"meta")]
		public KagiResultMetadata Metadata { get; init; }
	}
}
