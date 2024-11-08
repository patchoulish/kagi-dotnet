﻿using System;
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
		public static IEnumerable<object[]> SummarizeThrowOnBadRequestTestData =>
			[
				[
					new KagiSummarizeOptions()
					{
						Url = default,
						Text = default,
					}
				],
				[
					new KagiSummarizeOptions()
					{
						Url = new Uri("http://www.example.test"),
						Text = default,
					}
				],
				[
					new KagiSummarizeOptions()
					{
						Url = default,
						Text = String.Empty,
					}
				],
				[
					new KagiSummarizeOptions()
					{
						Url = new Uri("http://www.example.test"),
						Text = "Example Text",
					}
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> SummarizeTestData =>
			[
				[
					new KagiSummarizeOptions()
					{
						Url = new Uri("https://en.wikipedia.org/wiki/Millennium_Prize_Problems"),
						Text = default,
						AllowCaching = true,
						Kind = KagiSummaryKind.Takeaway,
						Engine = KagiSummaryEngine.Cecil,
						OutputLanguage = KagiSummaryLanguage.English,
					}
				],
				[
					new KagiSummarizeOptions()
					{
						Url = new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"),
						Text = default,
						AllowCaching = true,
						Kind = KagiSummaryKind.Summary,
						Engine = KagiSummaryEngine.Cecil,
						OutputLanguage = KagiSummaryLanguage.Japanese,
					}
				],
				[
					new KagiSummarizeOptions()
					{
						Url = new Uri("https://en.wikipedia.org/wiki/Neural_network"),
						Text = default,
						AllowCaching = true,
						Kind = KagiSummaryKind.Summary,
						Engine = KagiSummaryEngine.Cecil,
					}
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"Summarize")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SummarizeThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.SummarizeAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		[TestCategory(
			"Summarize")]
		[TestCategory(
			"BadRequest")]
		[DataTestMethod]
		[DynamicData(
			nameof(SummarizeThrowOnBadRequestTestData))]
		public async Task SummarizeThrowOnBadRequestTestAsync(
			KagiSummarizeOptions options)
		{
			await Assert.ThrowsExceptionAsync<KagiException>(
				() => this.kagi.SummarizeAsync(
					options));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		[TestCategory(
			"Summarize")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(SummarizeTestData))]
		public async Task SummarizeTestAsync(
			KagiSummarizeOptions options)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var summarizeResult =
				await this.kagi
					.SummarizeAsync(
						options);

			Assert.IsNotNull(
				summarizeResult);

			Assert.IsNotNull(
				summarizeResult.Metadata);
		}
	}
}
