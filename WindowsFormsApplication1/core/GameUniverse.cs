using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
	public class GameUniverse
	{
		public List<bool[,]> previousState { get; set; }

		public Cell[,] CellMatrix { get; set; }

		public virtual bool Update() { return true; }

		public virtual bool CheckPreviousStates(bool[,] newState) { return true; }

		public virtual void CheckCells() { }

		public GameUniverse() {

		}
	}
}
