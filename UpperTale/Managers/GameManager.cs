using System.Collections.Generic;
using Something.Interfaces;
using Something.View.Screens;

namespace Something.Managers;

public static class GameManager
{
    private static Dictionary<string, Screen> _screens;
    private static Screen _currentScreen;

    private static readonly CollisionManager CollisionManager =
        new(new Rectangle(Point.Zero, new Point(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT)));
    

    public static void LoadScreens()
    {
        _screens = new Dictionary<string, Screen>
        {
            { "MenuScreen", new MenuScreen() },
            { "GameScreen", new GameScreen() },
            { "OptionsScreen", new OptionsScreen() }
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
        CollisionManager.CheckCollision();
        _currentScreen.UpdateEntities();
        ProjectileManager.Update();
    }

    public static void Draw()
    {
        _currentScreen.DrawEntities();
        ProjectileManager.Draw();
    }
    
    public static void ChangeScreen(string screenName)
    {
        _currentScreen = _screens[screenName];
        _currentScreen.Initialize();
    }
    
    public static void AnnihilateEntity(IEntity entity)
    {
        _currentScreen.AnnihilateEntity(entity);
        CollisionManager.RemoveCollidable(entity as ICollidable);
    }
}