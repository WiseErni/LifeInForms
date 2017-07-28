using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	class FixedUniverse : GameUniverse
	{
		public FixedUniverse(int x, int y) {
			UniverseMatrix = new int[x, y];
			CellMatrix = new Cell[x, y];
			for (int i = 0; i < x; i++) {
				for (int j = 0; j < y; j++)
				{
					CellMatrix[i, j].Neighbours = fetchNeighbors(i, j, x, y);
				}
			}
		}

		private List<Cell> fetchNeighbors(int i, int j, int x, int y)
		{
			List<Cell> nList = new List<Cell>();
			if (i == 0)
			{
				nList.Add(CellMatrix[i, j + 1]);
				nList.Add(CellMatrix[i + 1, j + 1]);
				nList.Add(CellMatrix[i + 1, j]);
			} else if (i == x) {

			} else {

			}
			if (j == 0)
			{

			} else if (j == y) {

			} else {

			}
			return nList;
		}

		public override void Update()
		{
			base.Update();			
		}
	}
}
