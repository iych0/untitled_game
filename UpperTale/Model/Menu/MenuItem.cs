using System;

namespace Something.Model.Menu;

public class MenuItem
{
    public readonly string Text;
    public readonly Action Action;
    public MenuItem(string text, Action action)
    {
        Text = text;
        Action = action;
    }
}