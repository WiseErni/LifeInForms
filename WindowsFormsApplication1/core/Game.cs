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

		private int lastState = 0;

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
				i--;
			}
			else if (i == 0)
			{
				i = 7;
				j--;
			}
			if (j == 8 && i != 0)
			{
				j--;
			}

			Universe.CellMatrix[i, j].IsAlive = state;
		}

		public void ChangeState (GameStates state) {
			State = state;
		}

		private void drawCells(bool useActualState, int prevStateIndex = 0)
		{
			if (useActualState)
			{
				for (var i = 0; i < 8; i++)
				{
					for (var j = 0; j < 8; j++)
					{
						((CheckBox)PresentationControls["checkBox" + ((j * 8 + i) + 1)]).CheckState = Universe.CellMatrix[i, j].IsAlive ? CheckState.Indeterminate : CheckState.Unchecked;
					}
				}
			}
			else
			{
				for (var i = 0; i < 8; i++)
				{
					for (var j = 0; j < 8; j++)
					{
						((CheckBox)PresentationControls["checkBox" + ((j * 8 + i) + 1)]).CheckState = Universe.previousState[prevStateIndex][i, j] ? CheckState.Indeterminate : CheckState.Unchecked;
					}
				}
			}
		}

		public async void RunGame() {
			if (State != GameStates.Paused) {
				((ListBox)PresentationControls["StateList"]).Items.Clear();
				((ListBox)PresentationControls["StateList"]).Items.Add("Generation 1");
				lastState++;
			}
			ChangeState(GameStates.Running);						
			while (State == GameStates.Running)
			{
				drawCells(true);
				if (Universe.Update())
				{
					((ListBox)PresentationControls["StateList"]).Items.Add("Generation " + Universe.previousState.Count);
					lastState++;
					await Task.Delay(500);
				}
				else
				{					
					ChangeState(GameStates.Stopped);
					MessageBox.Show("There is no more evolution possible.", "Game Over!", MessageBoxButtons.OK);
				}
			}
		}

		public void SelectPreviousState(int stateIndex)
		{
			if ( State == GameStates.Paused || State == GameStates.Stopped )
			{
				drawCells(false, stateIndex);
			}
		}
    }
}
