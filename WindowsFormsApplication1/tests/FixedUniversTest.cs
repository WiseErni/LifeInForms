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
		public FixedUniverse instanceTest;
		public FixedUniverse testUnivers;
		
		public void instantiateUnivers()
		{
			instanceTest = new FixedUniverse(50, 50);
		}
		[SetUp]
		public void setUp()
		{
			testUnivers = new FixedUniverse(50, 50);
		}
		[TearDown]
		public void tearDown()
		{
			testUnivers = null;
		}
		#region Instantiation Tests
		[Test]
		public void isUniversInstantiated()
		{
			Assert.DoesNotThrow(new TestDelegate(instantiateUnivers));
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
			testUnivers.Update();
			Assert.IsTrue(testUnivers.CellMatrix[1, 1].IsAlive && testUnivers.CellMatrix[1, 2].IsAlive
							&& testUnivers.CellMatrix[2, 1].IsAlive && testUnivers.CellMatrix[2, 2].IsAlive);
		}

		[Test]
		public void isNextStepCorrect()
		{
			testUnivers.CellMatrix[0, 0].IsAlive = true;
			testUnivers.CellMatrix[1, 0].IsAlive = true;
			testUnivers.CellMatrix[2, 0].IsAlive = true;
			testUnivers.Update();			
			Assert.IsTrue(testUnivers.CellMatrix[1, 1].IsAlive);
			testUnivers.Update();
			Assert.IsFalse(testUnivers.CellMatrix[1, 0].IsAlive);
		}
		#endregion
	}
}
