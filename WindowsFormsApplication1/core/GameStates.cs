using System.ComponentModel.DataAnnotations;

namespace LifeInForms.core
{
	public enum GameStates
	{
		[Display(Name = "Game is Running")]
		Running,

		[Display(Name = "Game is Paused")]
		Paused,

		[Display(Name = "Game Over")]
		Stopped
	}
}
