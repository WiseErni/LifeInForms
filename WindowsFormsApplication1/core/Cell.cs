using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	public class Cell
	{
		public bool IsAlive { get; set; }

		public Cell[] Neighbours { get; set; }

		public Cell() {
			IsAlive = false;
		}

		public void SetAliveState()
		{
			int aliveNeighbours = Neighbours.Count(cell => cell != null ? cell.IsAlive : false);
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
