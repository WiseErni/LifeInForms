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

			foreach(var control in Controls)
			{
				CheckBox cBox = control as CheckBox;
				if (cBox is CheckBox)
				{
					cBox.Click += checkBoxesClick;
				}
			}

			if (Game == null)
			{
				Game = new Game(Controls);
			}
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (Game == null) {
				Game = new Game(Controls);
			} else {
				if (Game.State != GameStates.Stopped)
				{
					Game.RunGame();
				}
			}			
		}

		private void PauseButton_Click(object sender, EventArgs e)
		{
			Game.ChangeState(GameStates.Paused);
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			Game.ChangeState(GameStates.Stopped);
			Game = null;
		}

		private void checkBoxesClick(object sender, EventArgs e)
		{
			Control control = sender as Control;
			string cName = control.Name;
			int cNum = 0;
			var _t = cName.IndexOf("checkBox");
			if (cName.IndexOf("checkBox") >= 0 && Int32.TryParse(cName.Substring(8), out cNum))
			{
				CheckBox checkBox = control as CheckBox;
				if (Game != null)
				{
					Game.ChangeCellState(cNum, checkBox.Checked);
	}
			}
		}
	}
}
