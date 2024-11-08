using System;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	internal static class Guard
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void NotNull(
			object argument,
			string paramName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					paramName);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static void NotNullOrEmpty(
			string argument,
			string paramName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					paramName);
			}

			if (String.IsNullOrEmpty(argument))
			{
				throw new ArgumentException(
					paramName);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static void NotNullOrWhiteSpace(
			string argument,
			string paramName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					paramName);
			}

			if (String.IsNullOrWhiteSpace(argument))
			{
				throw new ArgumentException(
					paramName);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="paramName"></param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static void NotNegativeOrZero(
			int argument,
			string paramName)
		{
			if (argument <= 0)
			{
				throw new ArgumentOutOfRangeException(
					paramName);
			}
		}
	}
}
