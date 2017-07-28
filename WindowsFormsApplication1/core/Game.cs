using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInForms.core
{
    class Game
    {
        public GameStates State { get; set; }

		private GameUniverse Universe { get; set; }

		public Game() {
			Universe = new FixedUniverse(50,50);
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
