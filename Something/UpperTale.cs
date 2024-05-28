﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Something.Managers;

namespace Something;

public class UpperTale : Game
{
    //TODO Make UpperTale a singleton
    
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
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

        _gameManager = new GameManager();
        _gameManager.LoadScreens();
        _gameManager.InitMenu();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.Update(gameTime);
        _gameManager.Update();

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
        _gameManager.Draw();
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}