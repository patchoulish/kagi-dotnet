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
		public static IEnumerable<object[]> SearchWebEnrichmentsTestData =>
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
			"SearchWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchWebEnrichmentsThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.SearchWebEnrichmentsAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"SearchWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchWebEnrichmentsThrowOnArgumentEmptyAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.SearchWebEnrichmentsAsync(
					String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[TestCategory(
			"SearchWebEnrichments")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(SearchWebEnrichmentsTestData))]
		public async Task SearchWebEnrichmentsAsync(
			string query)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var searchResult =
				await this.kagi
					.SearchWebEnrichmentsAsync(
						query);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
