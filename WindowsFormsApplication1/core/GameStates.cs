using System.ComponentModel.DataAnnotations;

namespace LifeInForms.core
{
	enum GameStates
	{
		[Display(Name = "Игра запущена")]
		Running,

		[Display(Name = "Игра на паузе")]
		Paused,

		[Display(Name = "Игра завершена")]
		Stopped
	}
}
