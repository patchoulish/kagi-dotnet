using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents the result of an errored operation.
	/// </summary>
	public class KagiErrorResult :
		KagiResult
	{
		/// <summary>
		/// The collection of <see cref="KagiError"/> that occurred, if any.
		/// </summary>
		[JsonPropertyName(
			"error")]
		public ImmutableArray<KagiError> Errors { get; init; }
	}
}
