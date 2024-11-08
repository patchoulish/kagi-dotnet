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
		public async Task AnswerThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.AnswerAsync(
					default));
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
		[DataTestMethod]
		[DynamicData(nameof(AnswerThrowOnBadRequestTestData))]
		public async Task AnswerThrowOnBadRequestAsync(
			KagiAnswerOptions options)
		{
			await Assert.ThrowsExceptionAsync<KagiException>(
				() => this.kagi.AnswerAsync(
					options));
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
		[DataTestMethod]
		[DynamicData(nameof(AnswerTestData))]
		public async Task AnswerAsync(
			KagiAnswerOptions options)
		{
			// Sleep for a bit to not stress Kagi out.
			Task.Delay(1000)
				.Wait();

			var answerResult =
				await this.kagi
					.AnswerAsync(
						options);

			Assert.IsNotNull(
				answerResult);

			Assert.IsNotNull(
				answerResult.Metadata);
		}
	}
}
