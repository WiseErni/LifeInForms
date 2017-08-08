using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	public class FixedUniverse : GameUniverse
	{
		private int width;
		private int height;

		public FixedUniverse(int x, int y) {
			width = x;
			height = y;
			previousState = new int[width, height];
			CellMatrix = new Cell[width, height];
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++)
				{
					CellMatrix[i, j] = new Cell();
					CellMatrix[i, j].Neighbours = fetchNeighbors(i, j);
				}
			}
		}

		private Cell[] fetchNeighbors(int i, int j)
		{
			Cell[] neighbors = new Cell[8];
			if (i >= 0 && j >= 0 && i < width && j < height)
			{
				int topShift = j - 1;
				int downShift = j + 1;
				int leftShift = i - 1;
				int rightShift = i + 1;

				if (downShift < height && topShift >= 0 && leftShift >= 0 && rightShift < width)
				{
					neighbors[0] = CellMatrix[leftShift, topShift] != null ? CellMatrix[leftShift, topShift] : null;
					neighbors[1] = CellMatrix[i, topShift] != null ? CellMatrix[i, topShift] : null;
					neighbors[2] = CellMatrix[rightShift, topShift] != null ? CellMatrix[rightShift, topShift] : null;
					neighbors[3] = CellMatrix[leftShift, j] != null ? CellMatrix[leftShift, j] : null;
					neighbors[4] = CellMatrix[rightShift, j] != null ? CellMatrix[rightShift, j] : null;
					neighbors[5] = CellMatrix[leftShift, downShift] != null ? CellMatrix[leftShift, downShift] : null;
					neighbors[6] = CellMatrix[i, downShift] != null ? CellMatrix[i, downShift] : null;
					neighbors[7] = CellMatrix[rightShift, downShift] != null ? CellMatrix[rightShift, downShift] : null;
				}
			}
			return neighbors;
		}

		public override void Update()
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					previousState[i, j] = CellMatrix[i, j].IsAlive ? 1 : 0;
					CellMatrix[i, j].Neighbours = fetchNeighbors(i, j);
					CellMatrix[i, j].CheckAliveState();				
				} 
			}
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (CellMatrix[i, j].NeedUpdate) {
						CellMatrix[i, j].IsAlive = CellMatrix[i, j].NewState;
						CellMatrix[i, j].NeedUpdate = false;
					}
				}
			}
		}
	}
}
