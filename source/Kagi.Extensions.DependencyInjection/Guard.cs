using System;

namespace Kagi
{
	/// <summary>
	/// Contains guard clauses for throwing exceptions.
	/// </summary>
	internal static class Guard
	{
		/// <summary>
		/// Throws an exception if the specified argument is null.
		/// </summary>
		/// <param name="argument">The argument specified.</param>
		/// <param name="argumentName">The name of the argument specified.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified argument is null.
		/// </exception>
		public static void NotNull(
			object argument,
			string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					argumentName);
			}
		}
	}
}
