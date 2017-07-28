using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	class GameUniverse
	{
		public int[,] UniverseMatrix { get; set; }

		public Cell[,] CellMatrix { get; set; }

		public virtual void Update() {

		}

		public GameUniverse() {

		}
	}
}
