using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
    public class Game
    {
        public GameStates State { get; set; }

		private GameUniverse Universe { get; set; }

		public Game() {
			Universe = new FixedUniverse(50,50);
			Universe.CellMatrix[0, 0].IsAlive = true;
			Universe.CellMatrix[1, 0].IsAlive = true;
			Universe.CellMatrix[2, 0].IsAlive = true;
			RunGame();
		}

		public void ChangeState (GameStates state) {
			State = state;
		}

		private async void RunGame() {
			ChangeState(GameStates.Running);
			while (State == GameStates.Running)
			{
				Universe.Update();
				await Task.Delay(100);
			}
		}
    }
}
