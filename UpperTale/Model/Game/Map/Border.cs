using Something.Interfaces;

namespace Something.Model.Game.Map;

public class Border : ICollidable
{
    public Rectangle Hitbox { get; set; }
    
    public Border(Point position, Point size)
    {
        Hitbox = new Rectangle(position, size);
    }
    public void OnCollision(ICollidable collidable)
    {
    }
}