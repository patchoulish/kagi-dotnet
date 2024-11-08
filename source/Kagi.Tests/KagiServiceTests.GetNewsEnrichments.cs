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
		public static IEnumerable<object[]> GetNewsEnrichmentsTestData =>
			[
				[
					"us presidential election 2024"
				],
				[
					"local news hokkaido japan"
				],
				[
					"san francisco"
				],
				[
					"meta latest llm models"
				],
				[
					"openai dev day"
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GetNewsEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetNewsEnrichmentsThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.GetNewsEnrichmentsAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GetNewsEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetNewsEnrichmentsThrowOnArgumentEmptyTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.GetNewsEnrichmentsAsync(
					String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[TestCategory(
			"GetNewsEnrichments")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(GetNewsEnrichmentsTestData))]
		public async Task GetNewsEnrichmentsTestAsync(
			string query)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var searchResult =
				await this.kagi
					.GetNewsEnrichmentsAsync(
						query);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
