using System.Collections.Generic;
using Something.Model;
using Something.Model.Game;
using IDrawable = Something.Model.Interfaces.IDrawable;

namespace Something.View.Screens;

public class GameScreen : Screen
{
    public override void Initialize()
    {
        Entities = new List<IDrawable>
        {
            new Map(),
            new Player(Globals.ScreenCenter),
        };
    }
}