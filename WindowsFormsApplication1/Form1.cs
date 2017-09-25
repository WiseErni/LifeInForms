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
					Game.IsNew = false;
				}
			}
			ManageButtonsState();
		}

		private void PauseButton_Click(object sender, EventArgs e)
		{
			Game.ChangeState(GameStates.Paused);
			ManageButtonsState();
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			if (Game != null)
			{
				Game.ChangeState(GameStates.Stopped);
				ManageButtonsState();
			}			
		}

		private void checkBoxesClick(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;
			int cNum = 0;
			if (Int32.TryParse(checkBox.Name.Substring(8), out cNum))
			{				
				checkBox.CheckState = checkBox.Checked ? CheckState.Indeterminate : CheckState.Unchecked;
				if (Game != null)
				{
					Game.ChangeCellState(cNum, checkBox.Checked);
				}
			}
		}

		private void RestartButton_Click(object sender, EventArgs e)
		{
			if (Game != null)
			{
				Game.ChangeState(GameStates.Stopped);
			}
			StateList.Items.Clear();
			foreach (var control in Controls)
			{
				CheckBox cBox = control as CheckBox;
				if (cBox is CheckBox)
				{
					cBox.Checked = false;
				}
			}
			Game = new Game(Controls);
			ManageButtonsState();
		}

		private void StateList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox list = sender as ListBox;
			if (Game != null && (Game.State == GameStates.Paused || Game.State == GameStates.Stopped))
			{
				Game.SelectPreviousState(list.SelectedIndex);
			}
		}

		private void ManageButtonsState()
		{
			if (Game != null)
			{
				StartButton.Enabled = Game.State == GameStates.Paused;
				PauseButton.Enabled = Game.State == GameStates.Running;
				StopButton.Enabled = (Game.State == GameStates.Running || Game.State == GameStates.Paused) && !Game.IsNew;
				RestartButton.Enabled = Game.State == GameStates.Stopped || Game.State == GameStates.Paused;
			}
		}
	}
}
