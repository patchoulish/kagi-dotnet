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
	partial class KagiClientTests
	{
		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> AnswerThrowOnBadRequestData =>
			[
				[
					new KagiAnswerOptions()
					{
						Query = default,
					}
				],
				[
					new KagiAnswerOptions()
					{
						Query = String.Empty,
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
				() => this.client.AnswerAsync(
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
		[DynamicData(nameof(AnswerThrowOnBadRequestData))]
		public async Task AnswerThrowOnBadRequestAsync(
			KagiAnswerOptions options)
		{
			await Assert.ThrowsExceptionAsync<KagiException>(
				() => this.client.AnswerAsync(
					options));
		}
	}
}
