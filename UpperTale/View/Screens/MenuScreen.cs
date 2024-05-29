using System.Collections.Generic;
using Something.Model.Interfaces;
using Something.Model.Menu;

namespace Something.View.Screens;

public class MenuScreen : Screen
{
    public override void Initialize()
    {
        Entities = new List<IDrawable>
        {
            new MenuBackground(),
            new MainMenu()
        };
    }
}