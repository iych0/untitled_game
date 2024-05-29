using System.Collections.Generic;
using Microsoft.Xna.Framework;
using IDrawable = Something.Model.Interfaces.IDrawable;
using Something.Extension;
using Something.Managers;
using Something.Model.Enums;

namespace Something.Model.Menu;

public class MainMenu : IDrawable
{
    private readonly List<MenuItem> _menuItems = new()
    {
        new MenuItem("New Game", ),
        new MenuItem("Continue"),
        new MenuItem("Options"),
        new MenuItem("Exit")
    };
    private int _selectedItem;
    private readonly Vector2 _position = Globals.ScreenCenter - new Vector2(100, 100);

    public void Draw()
    {
        for (int i = 0; i < _menuItems.Count; i++)
        {
            var color = i == _selectedItem ? Color.Red : Color.White;
            Globals.SpriteBatch.Draw(_menuItems[i].Text, _position with{Y = _position.Y + 50 * i}, color);
        }
    }

    public void Update()
    {
        if (InputManager.Moving && InputManager.Direction.X == 0)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            _selectedItem += InputManager.Direction.Y == -1 ? -1 : 1;
        }

        _selectedItem %= _menuItems.Count;
    }
}