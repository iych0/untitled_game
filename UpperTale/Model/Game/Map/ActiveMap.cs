using System.Collections.Generic;
using Something.Managers;

namespace Something.Model.Game.Map;

public class ActiveMap : IDrawable
{
    private readonly Texture2D _texture2D = Globals.Content.Load<Texture2D>("Textures/Maps/IslandMap");
    private readonly List<Border> _borders = new();
    private readonly Vector2 _position = new((Globals.ScreenSize.X - 1000) / 2, (Globals.ScreenSize.Y - 900) / 2);
    private readonly Vector2 _mapSize = new(1000, 900);
    public ActiveMap()
    {
        //
        _borders.Add(new Border(Point.Zero, new Point((int)Globals.ScreenSize.X, (int)_position.Y)));
        _borders.Add(new Border(new Point(0, (int)_position.Y), new Point((int)((Globals.ScreenSize.X - _mapSize.X)/2), (int)_mapSize.Y - 40)));
        _borders.Add(new Border(new Point(0, (int)(_position.Y + _mapSize.Y - 40)), new Point((int)Globals.ScreenSize.X, (int)_position.Y + 40)));
        _borders.Add(new Border(new Point((int)(_position.X + _mapSize.X), (int)_position.Y), new Point((int)((Globals.ScreenSize.X - _mapSize.X)/2), (int)_mapSize.Y - 40)));

        foreach (var border in _borders)
            CollisionManager.AddCollidable(border);
    }
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture2D, _position, 
            null,
            Color.White, 0f, Vector2.One, 1f, SpriteEffects.None, 0f);
        
        foreach (var border in _borders) Debug.DrawHitbox(border.Hitbox);
    }

    public void Update()
    {
    }
}