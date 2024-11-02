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
			"Answer")]
		[TestCategory(
			"Argument")]
		public async Task AnswerThrowOnArgumentNullAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.client.AnswerAsync(
					default));
		}
	}
}
