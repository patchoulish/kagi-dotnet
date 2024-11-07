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
	public sealed partial class KagiServiceTests
	{
		private KagiService kagi;

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			var clientApiKey = "AgCA7gnvCwc.-SVgHlK0ITk8-2vJRtkNyT-NMm5REOSPpIAskwoE7Gc";

			this.kagi =
				new KagiService(
					clientApiKey);
		}
	}
}
