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
			"SearchWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchWebEnrichmentsThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.kagi.SearchWebEnrichmentsAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"SearchWebEnrichments")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task SearchWebEnrichmentsThrowOnArgumentEmptyAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.kagi.SearchWebEnrichmentsAsync(
					String.Empty));
		}
	}
}
