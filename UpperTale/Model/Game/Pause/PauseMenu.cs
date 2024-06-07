using System.Collections.Generic;
using System.Timers;
using Something.Extensions;
using Something.Managers;
using Something.Model.Menu;

namespace Something.Model.Game.Pause;

public class PauseMenu : IDrawable
{
    private readonly Timer _buttonCooldown = new(100);
    
    private readonly List<MenuItem> _menuItems = new()
    {
        new MenuItem("Resume", GameManager.UnpauseGame),
        new MenuItem("Options", () => GameManager.ChangeScreen("OptionsScreen")),
        new MenuItem("Main Menu", () =>
        {
            GameManager.ChangeScreen("MenuScreen");
            GameManager.UnpauseGame();
        }),
        new MenuItem("Exit Game", GameManager.ExitGame),
    };
    private int _selectedItem;
    private readonly Vector2 _position = Globals.ScreenCenter - new Vector2(100, 70);

    public PauseMenu()
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
            _selectedItem += InputManager.Direction.Y == -1 ? -1 : 1;
            _buttonCooldown.Start();
        }

        _selectedItem %= _menuItems.Count;
    }
}