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
			await Assert.ThrowsAsync<ArgumentNullException>(
				() => this.kagi.GetNewsEnrichmentsAsync(
					default,
					TestContext.CancellationToken));
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
			await Assert.ThrowsAsync<ArgumentException>(
				() => this.kagi.GetNewsEnrichmentsAsync(
					String.Empty,
					TestContext.CancellationToken));
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
		[TestMethod]
		[DynamicData(
			nameof(GetNewsEnrichmentsTestData))]
		public async Task GetNewsEnrichmentsTestAsync(
			string query)
		{
			// Sleep for a bit to not stress Kagi out.
			Task
				.Delay(
					1000,
					TestContext.CancellationToken)
				.Wait(
					TestContext.CancellationToken);

			var searchResult =
				await this.kagi
					.GetNewsEnrichmentsAsync(
						query,
						TestContext.CancellationToken);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
