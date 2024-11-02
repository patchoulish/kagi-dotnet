using System;
using System.Threading;
using System.Threading.Tasks;

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
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.client.SearchAsync(
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
		public async Task SearchThrowOnArgumentEmptyAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.client.SearchAsync(
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
		public async Task SearchThrowOnArgumentOutOfRangeAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
				() => this.client.SearchAsync(
					"query",
					0));

			await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
				() => this.client.SearchAsync(
					"query",
					-1));
		}
	}
}
