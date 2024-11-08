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
		public static IEnumerable<object[]> SearchNewsEnrichmentsTestData =>
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
			"SearchNewsEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchNewsEnrichmentsThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.SearchNewsEnrichmentsAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"SearchNewsEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchNewsEnrichmentsThrowOnArgumentEmptyAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.SearchNewsEnrichmentsAsync(
					String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[TestCategory(
			"SearchNewsEnrichments")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(SearchNewsEnrichmentsTestData))]
		public async Task SearchNewsEnrichmentsAsync(
			string query)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var searchResult =
				await this.kagi
					.SearchNewsEnrichmentsAsync(
						query);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
