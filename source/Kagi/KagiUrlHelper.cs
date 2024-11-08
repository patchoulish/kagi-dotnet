using System;

namespace Kagi
{
	/// <summary>
	/// Provides <see cref="Uri"/>-related helper functionality.
	/// </summary>
	public static class KagiUrlHelper
	{
		/// <summary>
		/// The prefix that proxied image URL path fragments start with.
		/// </summary>
		private const string ImageProxyPathFragment =
			"/proxy";

		/// <summary>
		/// The proxy image base URL i.e. what a proxied image URL
		/// path fragment requires to be a complete URL.
		/// </summary>
		private const string ImageProxyBaseUrlValue =
			"https://kagi.com/";

		/// <summary>
		/// Gets the proxy image base URL i.e. what a proxied image URL
		/// path fragment requires to be a complete URL.
		/// </summary>
		public static Uri ImageProxyBaseUrl { get; } =
			new Uri(ImageProxyBaseUrlValue);

		/// <summary>
		/// Returns whether the specified path fragment is an image proxy URL path fragment.
		/// </summary>
		/// <param name="value">The path fragment specified.</param>
		/// <returns></returns>
		/// <remarks>
		/// Used internally when fixing-up <see cref="KagiRecordSearchDataThumbnail.Url"/>.
		/// You will probably have no use for this method.
		/// </remarks>
		public static bool IsImageProxyPathFragment(
			string value)
		{
			Guard.NotNull(
				value,
				nameof(value));

			return value
				.StartsWith(
					ImageProxyPathFragment);
		}

		/// <summary>
		/// Returns a complete image proxy URL for the specified image proxy URL path fragment.
		/// </summary>
		/// <param name="value">The image proxy URL path fragment specified.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">
		/// Thrown when a image proxy URL cannot be created.
		/// </exception>
		/// <remarks>
		/// Used internally when fixing-up <see cref="KagiRecordSearchDataThumbnail.Url"/>.
		/// You will probably have no use for this method.
		/// </remarks>
		public static Uri ToImageProxyUrl(
			string value)
		{
			Guard.NotNull(
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
