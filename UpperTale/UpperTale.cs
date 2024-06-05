using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Something.Managers;

namespace Something;

public class UpperTale : Game
{
    //Make UpperTale a singleton class
    
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Matrix _transformMatrix;
    private const float Zoom = Config.SCREEN_ZOOM;
    
    public UpperTale()
    {
        _graphics = new GraphicsDeviceManager(this);
        Globals.Graphics = _graphics;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = Config.SCREEN_WIDTH;
        _graphics.PreferredBackBufferHeight = Config.SCREEN_HEIGHT;
        _graphics.ApplyChanges();
        _transformMatrix = Matrix.CreateScale(Zoom);

        Globals.Content = Content;
        
        GameManager.LoadScreens();
        GameManager.InitGameFromMenuScreen();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
    }

    protected override void Update(GameTime gameTime)
    {
        Globals.Update(gameTime);
        GameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
    var origin = Globals.ScreenCenter;
    
    _transformMatrix = 
        Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *
        Matrix.CreateScale(Zoom) *
        Matrix.CreateTranslation(new Vector3(origin, 0.0f));
        
        GraphicsDevice.Clear(Color.Beige);
        
        _spriteBatch.Begin(transformMatrix: _transformMatrix);
        GameManager.Draw();
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}