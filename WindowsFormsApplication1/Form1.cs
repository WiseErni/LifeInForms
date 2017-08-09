using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifeInForms.core;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
		private Game Game { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (Game == null) {
				Game = new Game(Controls);
			} else {
				Game.ChangeState(GameStates.Running);
			}			
		}

		private void PauseButton_Click(object sender, EventArgs e)
		{
			Game.ChangeState(GameStates.Paused);
		}
	}
}
