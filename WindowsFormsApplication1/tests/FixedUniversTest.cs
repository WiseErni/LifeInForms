using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LifeInForms.core;

namespace LifeInForms.tests
{
	/// <summary>
	/// Fixture that test fixed type game univers
	/// </summary>
	[TestFixture]
	public class FixedUniversTests
	{
		public FixedUniverse testUnivers;
		#region Instantiation Tests
		[Test]
		public void isUniversInstantiated()
		{
			Assert.DoesNotThrow(new TestDelegate(instantiateUnivers));
		}		
		private void instantiateUnivers()
		{
			testUnivers = new FixedUniverse(50, 50);
		}
		#endregion
		#region Game update tests
		[Test]
		public void isUpdateCorrect() {
			//Set test cells
			testUnivers.CellMatrix[1, 1].IsAlive = true;
			testUnivers.CellMatrix[1, 2].IsAlive = true;
			testUnivers.CellMatrix[2, 1].IsAlive = true;
			testUnivers.Update();
			Assert.IsTrue(testUnivers.CellMatrix[2, 2].IsAlive);
		}
		#endregion
	}
}
