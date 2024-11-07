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
	}
}
