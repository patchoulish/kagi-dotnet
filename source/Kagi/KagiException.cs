using System;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// Represents the exception thrown by instances of the
	/// <see cref="KagiService"/> and <see cref="KagiDelegatingHandler"/>
	/// classes.
	/// </summary>
	public class KagiException :
		HttpRequestException
	{
#if NETSTANDARD

		/// <summary>
		/// Gets the HTTP status code for this exception, if any.
		/// </summary>
		public HttpStatusCode? StatusCode { get; private init; }

#endif

		/// <summary>
		/// Gets a read-only collection of <see cref="KagiError"/> for this exception.
		/// </summary>
		public ImmutableArray<KagiError> Errors { get; private init; }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/> class.
		/// </summary>
		public KagiException() :
			this(
				default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		public KagiException(
			string message) :
				this(
					message,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception and an
		/// inner exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
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
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception, an
		/// inner exception, and an HTTP status code.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
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
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception, an
		/// inner exception, an HTTP status code, and a collection of
		/// <see cref="KagiError"/>.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		/// <param name="errors">
		/// A collection of <see cref="KagiError"/>.
		/// </param>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception, an
		/// inner exception, and an HTTP status code.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
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
		/// Initializes a new instance of the <see cref="KagiException"/> class
		/// with a specific message that describes the current exception, an
		/// inner exception, an HTTP status code, and a collection of
		/// <see cref="KagiError"/>.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		/// <param name="errors">
		/// A collection of <see cref="KagiError"/>.
		/// </param>
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
