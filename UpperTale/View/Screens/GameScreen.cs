using System.Collections.Generic;
using Something.Model.Game;

namespace Something.View.Screens;

public class GameScreen : Screen
{
    public override void Initialize()
    {
        Entities = new List<IDrawable>
        {
            new GameBackground(),
            new Map(),
            new Player(Globals.ScreenCenter),
        };
    }
}