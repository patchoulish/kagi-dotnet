using System;
using System.Collections;
using System.Collections.Immutable;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public class KagiException :
		Exception
	{
		/// <summary>
		/// 
		/// </summary>
		public ImmutableArray<KagiError> Errors { get; init; }

		/// <summary>
		/// 
		/// </summary>
		public KagiException() :
			this(
				default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public KagiException(
			string message) :
				this(
					message,
					default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errors"></param>
		public KagiException(
			string message,
			ImmutableArray<KagiError> errors) :
				this(
					message,
					errors,
					default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errors"></param>
		/// <param name="innerException"></param>
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
