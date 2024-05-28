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
            { "GameScreen", new GameScreen() }
        };
    }
    
    public void InitMenu()
    {
        _currentScreen = _screens["GameScreen"];
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
}