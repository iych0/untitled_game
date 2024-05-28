using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Something.Generators;
using Something.Managers;
using IDrawable = Something.Model.Interfaces.IDrawable;

namespace Something.Model;

public class Map : IDrawable
{
    private readonly Texture2D _texture2D = Globals.Content.Load<Texture2D>("textures/map");
    
    private readonly Texture2D _floorTexture = Globals.Content.Load<Texture2D>("textures/map_floor");
    private readonly Texture2D _wallTexture = Globals.Content.Load<Texture2D>("textures/map_wall");
    
    private readonly int _mapHeight = Config.MAP_TILES_HEIGTH;
    private readonly int _mapWidth = Config.MAP_TILES_WIDTH;
    private readonly int _tileSize = Config.TILE_SIZE;
    private int[,] _map;

    public Map()
    {
        var mapGenerator = new MapGenerator(_mapWidth, _mapHeight);
        _map = mapGenerator.GenerateMap();
    }
    
    public void Draw()
    {
        for (var x = 0; x < _mapWidth; x++)
        for (var y = 0; y < _mapHeight; y++)
        {
            Globals.SpriteBatch.Draw(_map[x, y] == 1 ? _wallTexture : _floorTexture,
                new Vector2(x * _tileSize, y * _tileSize), Color.White);
        }
        
        /*Globals.SpriteBatch.Draw(_texture2D, Globals.ScreenCenter - Globals.ScreenCenter/2,
            null,
            Color.White, 0f, Vector2.One, 1f, SpriteEffects.None, 0f); */
    }

    public void Update()
    {
        return;
    }
    
}