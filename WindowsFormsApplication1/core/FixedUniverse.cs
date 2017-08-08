using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	public class FixedUniverse : GameUniverse
	{
		public FixedUniverse(int x, int y) {
			UniverseMatrix = new int[x, y];
			CellMatrix = new Cell[x, y];
			for (int i = 0; i < x; i++) {
				for (int j = 0; j < y; j++)
				{
					CellMatrix[i, j] = new Cell();
					CellMatrix[i, j].Neighbours = fetchNeighbors(i, j, x, y);
				}
			}
		}

		private Cell[] fetchNeighbors(int i, int j, int x, int y)
		{
			Cell[] neighbors = new Cell[8];
			if (i >= 0 && j >= 0 && i < x && j < y)
			{
				int topShift = j - 1;
				int downShift = j + 1;
				int leftShift = i - 1;
				int rightShift = i + 1;

				if (topShift >= 0 && downShift < y)
				{
					if (leftShift >= 0)
					{
						neighbors[0] = CellMatrix[leftShift, topShift] != null ? CellMatrix[leftShift, topShift] : null;
						neighbors[3] = CellMatrix[leftShift, j] != null ? CellMatrix[leftShift, j] : null;
						neighbors[5] = CellMatrix[leftShift, downShift] != null ? CellMatrix[leftShift, downShift] : null;
					}
					if (rightShift < x)
					{
						neighbors[2] = CellMatrix[rightShift, topShift] != null ? CellMatrix[rightShift, topShift] : null;
						neighbors[4] = CellMatrix[rightShift, j] != null ? CellMatrix[rightShift, j] : null;
						neighbors[7] = CellMatrix[rightShift, downShift] != null ? CellMatrix[rightShift, downShift] : null;
					}

					neighbors[1] = CellMatrix[i, topShift] != null ? CellMatrix[i, topShift] : null;
					neighbors[6] = CellMatrix[i, downShift] != null ? CellMatrix[i, downShift] : null;
				}

			}
			return neighbors;
		}

		public override void Update()
		{
			base.Update();			
		}
	}
}
