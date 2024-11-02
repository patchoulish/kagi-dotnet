using System;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents an exception that wraps zero or more
	/// <see cref="KagiError"/> for a given operation.
	/// </summary>
	public class KagiException :
		Exception
	{
		/// <summary>
		/// The collection of <see cref="KagiError"/> for the exception.
		/// </summary>
		public ImmutableArray<KagiError> Errors { get; init; }

		/// <inheritdoc />
		public KagiException() :
			this(
				default)
		{ }

		/// <inheritdoc />
		public KagiException(
			string message) :
				this(
					message,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/>
		/// class with a specified error message and collection of <see cref="KagiError"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="errors">A collection of <see cref="KagiError"/> for the exception.</param>
		public KagiException(
			string message,
			ImmutableArray<KagiError> errors) :
				this(
					message,
					errors,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/>
		/// class with a specified error message, collection of <see cref="KagiError"/>,
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="errors">A collection of <see cref="KagiError"/> for the exception.</param>
		/// <param name="innerException">The inner exception that is the cause of this exception.</param>
		public KagiException(
			string message,
			ImmutableArray<KagiError> errors,
			Exception innerException) :
				base(
					message,
					innerException)
		{
			Errors = errors;
		}
	}
}
