using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeInForms.core
{
    public class Game
    {
        public GameStates State { get; set; }

		private Control.ControlCollection presentationControls;

		public Control.ControlCollection PresentationControls
		{
			get
			{
				return presentationControls;
			}
			private set
			{
				presentationControls = value;
			}
		}

		private GameUniverse Universe { get; set; }

		public Game(Control.ControlCollection controls) {
			Universe = new FixedUniverse(8, 8);
			//Universe.CellMatrix[2, 0].IsAlive = true;
			//Universe.CellMatrix[2, 1].IsAlive = true;
			//Universe.CellMatrix[2, 2].IsAlive = true;
			//Universe.CellMatrix[0, 1].IsAlive = true;
			//Universe.CellMatrix[1, 2].IsAlive = true;
			PresentationControls = controls;
		}

		public void ChangeCellState(int CellNum, bool state)
		{
			var i = 0;
			var j = 0;

			i = CellNum % 8;
			j = CellNum / 8;

			if (i > 0)
			{
				i -= 1;
			}
			if (j == 8)
			{
				j -= 1;
			}

			Universe.CellMatrix[i, j].IsAlive = state;
		}

		public void ChangeState (GameStates state) {
			State = state;
		}

		private void drawCells() {
			for (var i = 0; i < 8; i++)
			{
				for (var j = 0; j < 8; j++)
				{
					((CheckBox)PresentationControls["checkBox" + ((j * 8 + i) + 1)]).Checked = Universe.CellMatrix[i, j].IsAlive;
				}
			}
		}

		public async void RunGame() {
			ChangeState(GameStates.Running);
			while (State == GameStates.Running)
			{
				drawCells();
				Universe.Update();
				await Task.Delay(1000);
			}
		}
    }
}
