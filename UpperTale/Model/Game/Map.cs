using Something.Generators;

namespace Something.Model.Game;

public class Map : IDrawable
{
    private readonly Texture2D _texture2D = Globals.Content.Load<Texture2D>("Textures/Maps/IslandMap_1");
    
    //private readonly Texture2D _floorTexture = Globals.Content.Load<Texture2D>("textures/map_floor");
    //private readonly Texture2D _wallTexture = Globals.Content.Load<Texture2D>("textures/map_wall");

    private const int MapHeight = Config.MAP_TILES_HEIGTH;
    private const int MapWidth = Config.MAP_TILES_WIDTH;

    // private readonly int _tileSize = Config.TILE_SIZE;
    public Rectangle Hitbox { get; set; }
    private int[,] _map;

    public Map()
    {
        var mapGenerator = new MapGenerator(MapWidth, MapHeight);
        Hitbox = new Rectangle(Point.Zero, new Point(MapWidth - 400, MapHeight - 400));
        _map = mapGenerator.GenerateMap();
    }
    
    public void Draw()
    {
        /*for (var x = 0; x < _mapWidth; x++)
        for (var y = 0; y < _mapHeight; y++)
        {
            Globals.SpriteBatch.Draw(_map[x, y] == 1 ? _wallTexture : _floorTexture,
                new Vector2(x * _tileSize, y * _tileSize), Color.White);
        }*/
        
        Globals.SpriteBatch.Draw(_texture2D, new Vector2(200, 100), 
            null,
            Color.White, 0f, Vector2.One, 1f, SpriteEffects.None, 0f);
    }

    public void Update()
    {
        return;
    }
}