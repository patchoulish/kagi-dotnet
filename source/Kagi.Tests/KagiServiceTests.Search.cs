using System;
using System.Threading;
using System.Threading.Tasks;

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
		/// <returns></returns>
		[TestCategory(
			"Search")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchThrowOnArgumentNullAsync()
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
		public async Task SearchThrowOnArgumentEmptyAsync()
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
		public async Task SearchThrowOnArgumentOutOfRangeAsync()
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
	}
}
