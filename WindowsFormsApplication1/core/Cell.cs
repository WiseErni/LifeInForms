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
		public bool NeedUpdate { get; set; }
		public bool NewState;

		public Cell[] Neighbours { get; set; }

		public Cell() {
			IsAlive = false;
		}

		private int getAliveNeighbors()
		{
			return Neighbours.Count(cell => cell != null ? cell.IsAlive : false);
		}

		public void CheckAliveState()
		{
			int aliveNeighbours = getAliveNeighbors();
			if (IsAlive && (aliveNeighbours == 2 || aliveNeighbours == 3))
			{
				NeedUpdate = false;
				return;
			}
			if (!IsAlive && aliveNeighbours == 3)
			{
				NewState = true;
				NeedUpdate = true;
				return;
			} else if (!IsAlive)
			{
				NeedUpdate = false;
				return;
			}
			NewState = false;
			NeedUpdate = true;
		}		
	}
}
