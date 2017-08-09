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
				}
			}
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
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
				if (leftShift >= 0)
				{
					neighbors[3] = CellMatrix[leftShift, j] != null ? CellMatrix[leftShift, j] : null;
				}
				if (rightShift < width)
				{
					neighbors[4] = CellMatrix[rightShift, j] != null ? CellMatrix[rightShift, j] : null;
				}
				if (topShift >= 0)
				{
					neighbors[1] = CellMatrix[i, topShift] != null ? CellMatrix[i, topShift] : null;
					if (leftShift >= 0)
					{
						neighbors[0] = CellMatrix[leftShift, topShift] != null ? CellMatrix[leftShift, topShift] : null;
					}
					if (rightShift < width)
					{
						neighbors[2] = CellMatrix[rightShift, topShift] != null ? CellMatrix[rightShift, topShift] : null;
					}
				}
				if (downShift < height)
				{
					neighbors[6] = CellMatrix[i, downShift] != null ? CellMatrix[i, downShift] : null;
					if (leftShift >= 0)
					{
						neighbors[5] = CellMatrix[leftShift, downShift] != null ? CellMatrix[leftShift, downShift] : null; 
					}
					if (rightShift < width)
					{
						neighbors[7] = CellMatrix[rightShift, downShift] != null ? CellMatrix[rightShift, downShift] : null; 
					}
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
