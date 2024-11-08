using System;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kagi.Extensions.DependencyInjection
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed class ServiceCollectionExtensionsTests
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"ServiceCollectionExtensions")]
		[TestCategory(
			"AddKagiHttpClient")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void AddKagiHttpClientThrowOnArgumentNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => ServiceCollectionExtensions
					.AddKagiHttpClient(
						default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"ServiceCollectionExtensions")]
		[TestCategory(
			"AddKagiHttpClient")]
		[TestCategory(
			"Result")]
		[TestMethod]
		public void AddKagiHttpClient()
		{
			var services =
				new ServiceCollection();

			services.AddKagiHttpClient(
				(options) =>
				{
					options.ApiKey =
						Environment.GetEnvironmentVariable(
							"KAGI_API_KEY");
				});

			var serviceProvider =
				services.BuildServiceProvider();

			var kagi =
				serviceProvider.GetService<IKagiService>();

			Assert.IsNotNull(
				kagi);
		}
	}
}
