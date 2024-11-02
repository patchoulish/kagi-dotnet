using System;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kagi
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed partial class KagiClientTests
	{
		private KagiClient client;

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			var clientApiKey =
				Environment.GetEnvironmentVariable(
					"KAGI_API_KEY");

			this.client =
				new KagiClient(
					clientApiKey);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCleanup]
		public void Cleanup()
		{
			this.client
				.Dispose();
		}
	}
}
