using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	class Cell
	{
		public bool IsAlive { get; set; }

		public List<Cell> Neighbours { get; set; }

		public Cell() {

		}

		public void SetAliveState()
		{
			int aliveNeighbours = Neighbours.Count(x => x.IsAlive);
			if (IsAlive && (aliveNeighbours == 2 || aliveNeighbours == 3))
			{
				return;
			}
			if (!IsAlive && aliveNeighbours == 3)
			{
				IsAlive = true;
				return;
			}
			IsAlive = false;
		}
	}
}
