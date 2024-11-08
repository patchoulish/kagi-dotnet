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
	}
}
