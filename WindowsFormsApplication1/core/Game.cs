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
		
		private Control.ControlCollection presentationControls { get; set; }

		private GameUniverse Universe { get; set; }

		public Game(Control.ControlCollection controls) {
			Universe = new FixedUniverse(8, 8);
			Universe.CellMatrix[2, 1].IsAlive = true;
			Universe.CellMatrix[2, 2].IsAlive = true;
			Universe.CellMatrix[2, 3].IsAlive = true;
			Universe.CellMatrix[1, 3].IsAlive = true;
			Universe.CellMatrix[0, 2].IsAlive = true;
			presentationControls = controls;
			RunGame();
		}

		public void ChangeState (GameStates state) {
			State = state;
		}

		private void drawCells() {
			for (var i = 0; i < 8; i++)
			{
				for (var j = 0; j < 8; j++)
				{
					((CheckBox)presentationControls["checkBox" + ((j * 8 + i) + 1)]).Checked = Universe.CellMatrix[i, j].IsAlive;
				}
			}
		}

		private async void RunGame() {
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
