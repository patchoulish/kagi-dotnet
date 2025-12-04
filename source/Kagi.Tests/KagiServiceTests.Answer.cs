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
		public static IEnumerable<object[]> AnswerThrowOnBadRequestTestData =>
			[
				[
					new KagiAnswerOptions()
					{
						Query = default,
						AllowCaching = true
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = String.Empty,
						AllowCaching = true
					}
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> AnswerTestData =>
	[
		[
					new KagiAnswerOptions()
					{
						Query = "where was google founded?",
						AllowCaching = true
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = "what are the millennium prize problems?",
						AllowCaching = true
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = "what's a recipe for pound cake?",
						AllowCaching = true
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = "how many weeks of mandatory vacation are there in france?",
						AllowCaching = true
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = "what's the furthest height someone has skydived from?",
						AllowCaching = true
					}
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"Answer")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task AnswerThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(
				() => this.kagi.AnswerAsync(
					default,
					TestContext.CancellationToken));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		[TestCategory(
			"Answer")]
		[TestCategory(
			"BadRequest")]
		[TestMethod]
		[DynamicData(
			nameof(AnswerThrowOnBadRequestTestData))]
		public async Task AnswerThrowOnBadRequestTestAsync(
			KagiAnswerOptions options)
		{
			await Assert.ThrowsAsync<KagiException>(
				() => this.kagi.AnswerAsync(
					options,
					TestContext.CancellationToken));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		[TestCategory(
			"Answer")]
		[TestCategory(
			"Result")]
		[TestMethod]
		[DynamicData(
			nameof(AnswerTestData))]
		public async Task AnswerTestAsync(
			KagiAnswerOptions options)
		{
			// Sleep for a bit to not stress Kagi out.
			Task
				.Delay(
					1000,
					TestContext.CancellationToken)
				.Wait(
					TestContext.CancellationToken);

			var answerResult =
				await this.kagi
					.AnswerAsync(
						options,
						TestContext.CancellationToken);

			Assert.IsNotNull(
				answerResult);

			Assert.IsNotNull(
				answerResult.Metadata);
		}
	}
}
