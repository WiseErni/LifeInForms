using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LifeInForms.core;

namespace LifeInForms.tests
{
	[TestFixture]
	public class GameTest
	{
		public Game Game;
		[Test]
		public void checkGameInstantiation()
		{			
			Assert.DoesNotThrow(new TestDelegate(instantiateGame));
		}
		private void instantiateGame()
		{
			Game = new Game();
		}
	}
}
