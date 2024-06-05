using System.Collections.Generic;
using System.Timers;
using Something.Extensions;
using Something.Managers;

namespace Something.Model.Menu;

public class MainMenu : IDrawable
{
    private readonly Timer _buttonCooldown = new(100);
    
    private readonly List<MenuItem> _menuItems = new()
    {
        //TODO fix actions
        new MenuItem("New Game", () => GameManager.ChangeScreen("GameScreen")),
        new MenuItem("Continue", () => GameManager.ChangeScreen("GameScreen")),
        new MenuItem("Options", () => GameManager.ChangeScreen("OptionsScreen")),
        new MenuItem("Exit", () => GameManager.ChangeScreen("Exit")),
        new MenuItem("no russian", () => GameManager.ChangeScreen("dont do it")),
    };
    private int _selectedItem;
    private readonly Vector2 _position = Globals.ScreenCenter - new Vector2(100, 100);

    
    public MainMenu()
    {
        _buttonCooldown.Elapsed += (_, _) => _buttonCooldown.Stop();
    }
    
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
        if (_buttonCooldown.Enabled) return;
        if (InputManager.Action) _menuItems[_selectedItem].Action();
        if (InputManager.Moving && InputManager.Direction.X == 0)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            _selectedItem += InputManager.Direction.Y == -1 ? -1 : 1;
            _buttonCooldown.Start();
        }

        _selectedItem %= _menuItems.Count;
    }
}