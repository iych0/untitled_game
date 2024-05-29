using System.Collections.Generic;
using Something.View.Screens;

namespace Something.Managers;

public class GameManager
{
    private Dictionary<string, Screen> _screens;
    private Screen _currentScreen;
    

    public void LoadScreens()
    {
        _screens = new Dictionary<string, Screen>
        {
            { "MenuScreen", new MenuScreen() },
            { "GameScreen", new GameScreen() }
        };
    }
    
    public void InitMenu()
    {
        _currentScreen = _screens["MenuScreen"];
        _currentScreen.Initialize();
    }

    public void Update()
    {
        InputManager.Update();
        _currentScreen.UpdateEntities();
    }

    public void Draw()
    {
        _currentScreen.DrawEntities();
    }
    
    public void ChangeScreen(string screenName)
    {
        _currentScreen = _screens[screenName];
        _currentScreen.Initialize();
    }
}