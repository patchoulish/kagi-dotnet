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
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.SearchAsync(
					default,
					30));
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
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.SearchAsync(
					String.Empty,
					30));
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
			await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
				() => this.kagi.SearchAsync(
					"query",
					0));

			await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
				() => this.kagi.SearchAsync(
					"query",
					-1));
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
		[DataTestMethod]
		[DynamicData(
			nameof(SearchTestData))]
		public async Task SearchTestAsync(
			string query,
			int limit)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var searchResult =
				await this.kagi
					.SearchAsync(
						query,
						limit);

			Assert.IsNotNull(
				searchResult);

			Assert.IsNotNull(
				searchResult.Metadata);
		}
	}
}
