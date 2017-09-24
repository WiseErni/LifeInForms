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
			previousState = new List<bool[,]>();
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

		private bool _CompareTDArrays(bool[,] arrA, bool[,] arrB)
		{
			int _width = arrA.GetLength(0);
			int _height = arrA.GetLength(1);
			if (arrA.Length != arrB.Length || _width != arrB.GetLength(0) || _height != arrB.GetLength(1))
			{
				return false;
			}			
			for (var i = 0; i < _width; i++)
			{
				for (var j = 0; j < _height; j++)
				{
					if (arrA[i, j] != arrB[i, j])
					{
						return false;
					}
				}
			}
			return true;
		}

		public override bool CheckPreviousStates(bool[,] newState)
		{
			if (_CompareTDArrays(newState, previousState.Last())) 
			{
				return false;
			}
			else if (previousState.Exists(item => { return _CompareTDArrays(newState, item); }))
			{
				return false;
			}
			else
			{
				return true;
			}			
		}

		private bool[,] getStateFromCells(Cell[,] cellMatrix)
		{
			bool[,] stateArray = new bool[width, height];
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					stateArray[i, j] = CellMatrix[i, j].IsAlive ? true : false;					
				}
			}
			return stateArray;
		}

		public override bool Update()
		{
			// Add the begining state
			if (previousState.Count == 0)
			{
				previousState.Add(getStateFromCells(CellMatrix));
			}
			// Checking which cells need to be updated
			// Doing so without inplace updates to exclude grid corruption
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					CellMatrix[i, j].CheckAliveState();				
				} 
			}
			// Update the changed cells
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (CellMatrix[i, j].NeedUpdate)
					{
						CellMatrix[i, j].IsAlive = CellMatrix[i, j].NewState;
						CellMatrix[i, j].NeedUpdate = false;
					}
				}
			}
			
			if (CheckPreviousStates(getStateFromCells(CellMatrix)))
			{
				previousState.Add(getStateFromCells(CellMatrix));
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
