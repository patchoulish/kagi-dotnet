using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kagi
{
	partial class KagiServiceTests
	{
		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetWebEnrichmentsTestData =>
			[
				[
					"coffee enthusiast blog"
				],
				[
					"arts and crafts"
				],
				[
					"starslatecodex"
				],
				[
					"new york-style pizza"
				],
				[
					"open-source"
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GetWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetWebEnrichmentsThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.GetWebEnrichmentsAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GetWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetWebEnrichmentsThrowOnArgumentEmptyTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.GetWebEnrichmentsAsync(
					String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[TestCategory(
			"GetWebEnrichments")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(GetWebEnrichmentsTestData))]
		public async Task GetWebEnrichmentsTestAsync(
			string query)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var searchResult =
				await this.kagi
					.GetWebEnrichmentsAsync(
						query);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
