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
		[TestMethod]
		[TestCategory(
			"Summarize")]
		[TestCategory(
			"Argument")]
		public async Task SummarizeThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.client.SummarizeAsync(
					default));
		}
	}
}
