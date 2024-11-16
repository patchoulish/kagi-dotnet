using System;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents an exception that wraps zero or more
	/// <see cref="KagiError"/> for a given operation.
	/// </summary>
	public class KagiException :
		HttpRequestException
	{
#if NETSTANDARD

		/// <summary>
		/// Gets the <see cref="HttpStatusCode"/> for this exception, if any.
		/// </summary>
		public HttpStatusCode? StatusCode { get; private init; }

#endif

		/// <summary>
		/// Gets a read-only collection of <see cref="KagiError"/> for this exception.
		/// </summary>
		public ImmutableArray<KagiError> Errors { get; private init; }

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

		/// <inheritdoc />
		public KagiException(
			string message,
			Exception innerException) :
				this(
					message,
					innerException,
					default)
		{ }

#if NETSTANDARD

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/>
		/// class with a specified error message, a reference to the inner
		/// exception that is the cause of this exception, and the status
		/// code for this exception, if any.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The inner exception that is the cause of this exception.</param>
		/// <param name="statusCode">The HTTP status code for this exception, if any.</param>
		public KagiException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode) :
				this(
					message,
					innerException,
					statusCode,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/>
		/// class with a specified error message, collection of <see cref="KagiError"/>,
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The inner exception that is the cause of this exception.</param>
		/// <param name="statusCode">The HTTP status code for this exception, if any.</param>
		/// <param name="errors">A collection of <see cref="KagiError"/> for the exception.</param>
		public KagiException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode,
			ImmutableArray<KagiError> errors) :
				base(
					message,
					innerException)
		{
			StatusCode = statusCode;
			Errors = errors;
		}

#endif

#if NET

		/// <inheritdoc />
		public KagiException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode) :
				this(
					message,
					innerException,
					statusCode,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/>
		/// class with a specified error message, collection of <see cref="KagiError"/>,
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The inner exception that is the cause of this exception.</param>
		/// <param name="statusCode">The HTTP status code for this exception, if any.</param>
		/// <param name="errors">A collection of <see cref="KagiError"/> for the exception.</param>
		public KagiException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode,
			ImmutableArray<KagiError> errors) :
				base(
					message,
					innerException,
					statusCode)
		{
			Errors = errors;
		}

#endif
	}
}
