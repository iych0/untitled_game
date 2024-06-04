using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Something.Enums;
using Something.Managers;

namespace Something;

public sealed class Globals
{
    public static float TotalSeconds { get; private set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDeviceManager Graphics { get; set; }
    
    public static GameState GameState { get; set; }
    
    public static Vector2 ScreenSize => new(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
    
    public static Vector2 ScreenCenter => new(Graphics.PreferredBackBufferWidth / 2, Graphics.PreferredBackBufferHeight / 2);

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}