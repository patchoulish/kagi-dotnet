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
		public static IEnumerable<object[]> SearchTestData =>
			[
				[
					"pound cake recipes",
					20
				],
				[
					"restaurants near me",
					15
				],
				[
					"weather in san francisco",
					10
				],
				[
					"attention is all you need paper",
					5
				],
				[
					"general relativity wikipedia",
					1
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(
				() => this.kagi.SearchAsync(
					default,
					30,
					TestContext.CancellationToken));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchThrowOnArgumentEmptyTestAsync()
		{
			await Assert.ThrowsAsync<ArgumentException>(
				() => this.kagi.SearchAsync(
					String.Empty,
					30,
					TestContext.CancellationToken));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchThrowOnArgumentOutOfRangeTestAsync()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
				() => this.kagi.SearchAsync(
					"query",
					0,
					TestContext.CancellationToken));

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
				() => this.kagi.SearchAsync(
					"query",
					-1,
					TestContext.CancellationToken));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Result")]
		[TestCategory(
			"Manual")]
		[TestMethod]
		[DynamicData(
			nameof(SearchTestData))]
		public async Task SearchTestAsync(
			string query,
			int limit)
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
					.SearchAsync(
						query,
						limit,
						TestContext.CancellationToken);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
