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
		private KagiService client;

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			var clientApiKey = "AgCA7gnvCwc.-SVgHlK0ITk8-2vJRtkNyT-NMm5REOSPpIAskwoE7Gc";

			this.client =
				new KagiService(
					clientApiKey);
		}
	}
}
