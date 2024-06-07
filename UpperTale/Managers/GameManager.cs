using System;
using System.Collections.Generic;
using Something.Interfaces;
using Something.View.Screens;

namespace Something.Managers;

public static class GameManager
{
    private static Dictionary<string, Screen> _screens;
    private static Screen _currentScreen;
    private static PauseScreen _pauseScreen;
    private static bool _isPaused;

    private static readonly CollisionManager CollisionManager =
        new(new Rectangle(Point.Zero, new Point(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT)));
    

    public static void LoadScreens()
    {
        _screens = new Dictionary<string, Screen>
        {
            { "MenuScreen", new MenuScreen() },
            { "GameScreen", new GameScreen() },
            { "OptionsScreen", new OptionsScreen() },
            { "PauseScreen", new PauseScreen() }
        };
    }
    
    public static void InitGameFromMenuScreen()
    {
        _currentScreen = _screens["MenuScreen"];
        _currentScreen.Initialize();
    }

    public static void Update()
    {
        InputManager.Update();
        if (_isPaused)
        {
            _pauseScreen.UpdateEntities();
            return;
        }
        CollisionManager.CheckCollision();
        _currentScreen.UpdateEntities();
        ProjectileManager.Update();
    }

    public static void Draw()
    {
        _currentScreen.DrawEntities();
        ProjectileManager.Draw();
        if (_isPaused) _pauseScreen.DrawEntities();
    }
    
    public static void ChangeScreen(string screenName)
    {
        _currentScreen = _screens[screenName];
        _currentScreen.Initialize();
    }
    
    public static void PauseGame()
    {
        _pauseScreen = new PauseScreen();
        _pauseScreen.Initialize();
        _isPaused = true;
    }
    
    public static void UnpauseGame()
    {
        _isPaused = false;
        _pauseScreen = null;
    }
    
    public static void AnnihilateEntity(IEntity entity)
    {
        _currentScreen.AnnihilateEntity(entity);
        CollisionManager.RemoveCollidable(entity as ICollidable);
    }
    
    public static void ExitGame() => Environment.Exit(0);
}