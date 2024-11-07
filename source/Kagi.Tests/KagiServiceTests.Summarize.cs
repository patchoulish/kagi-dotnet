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
		/// <returns></returns>
		[TestCategory(
			"Summarize")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SummarizeThrowOnArgumentNullAsync()
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
		[DynamicData(nameof(SummarizeThrowOnBadRequestTestData))]
		public async Task SummarizeThrowOnBadRequestAsync(
			KagiSummarizeOptions options)
		{
			await Assert.ThrowsExceptionAsync<KagiException>(
				() => this.kagi.SummarizeAsync(
					options));
		}
	}
}