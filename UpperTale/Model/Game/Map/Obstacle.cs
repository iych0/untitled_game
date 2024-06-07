using Something.Interfaces;

namespace Something.Model.Game.Map;

public class Obstacle : IEntity, IDrawable, ICollidable
{
    public Rectangle Hitbox { get; set; }
    protected Vector2 Position { get; }
    protected Texture2D _texture2D;
    
    public Obstacle(Vector2 position)
    {
        Position = position;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture2D, Position, Color.White);
        Debug.DrawHitbox(Hitbox);
    }

    public void Update()
    {
    }
    
    public void OnCollision(ICollidable collidable)
    {
    }
}