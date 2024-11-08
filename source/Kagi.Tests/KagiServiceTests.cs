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
			this.kagi =
				new KagiService(
					Environment.GetEnvironmentVariable(
						"KAGI_API_KEY"));
		}
	}
}
