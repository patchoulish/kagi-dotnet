using System;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	public static class KagiUrlHelper
	{
		/// <summary>
		/// 
		/// </summary>
		private const string ImageProxyPathFragment =
			"/proxy";

		/// <summary>
		/// 
		/// </summary>
		private const string ImageProxyBaseUrlValue =
			"https://kagi.com/";

		/// <summary>
		/// 
		/// </summary>
		public static Uri ImageProxyBaseUrl { get; } =
			new Uri(ImageProxyBaseUrlValue);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsImageProxyPathFragment(
			string value)
		{
			ArgumentNullException
				.ThrowIfNull(
					value,
					nameof(value));

			return value
				.StartsWith(
					ImageProxyPathFragment);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static Uri ToImageProxyUrl(
			string value)
		{
			ArgumentNullException
				.ThrowIfNull(
					value,
					nameof(value));

			if (Uri.TryCreate(
					ImageProxyBaseUrl,
					value.TrimStart('/'),
					out var result))
			{
				return result;
			}
			else
			{
				throw new InvalidOperationException(
					$"Failed to create a valid image proxy URL.");
			}
		}
	}
}
