using System.Collections.Generic;
using Something.Managers;
using Something.Model.Game.Pause;

namespace Something.View.Screens;

public class PauseScreen : Screen
{
    public override void Initialize()
    {
        Entities = new List<IDrawable>
        {
            new PauseBackground(),
            new PauseMenu()
        };
    }
    
    public override void UpdateEntities()
    {
        if (InputManager.Escape)
            GameManager.UnpauseGame();
        base.UpdateEntities();
    }
}