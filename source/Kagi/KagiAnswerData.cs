using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents the response data for a
	/// <see cref="KagiAnswerResult"/>.
	/// </summary>
	public class KagiAnswerData
	{
		/// <summary>
		/// The answer output.
		/// </summary>
		[JsonPropertyName(
			"output")]
		public string Output { get; init; }

		/// <summary>
		/// A collection of <see cref="KagiAnswerDataReference"/>
		/// search records that were utilized to produce the answer output.
		/// </summary>
		[JsonPropertyName(
			"references")]
		public ImmutableArray<KagiAnswerDataReference> References { get; init; }

		/// <summary>
		/// The number of tokens processed to produce the answer output.
		/// </summary>
		[JsonPropertyName(
			"tokens")]
		public int TokensProcessed { get; init; }
	}
}
