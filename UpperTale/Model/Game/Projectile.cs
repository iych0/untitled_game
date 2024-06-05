using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game;

public abstract class Projectile : IEntity, IDrawable, ICollidable
{
    protected int Velocity;
    protected Vector2 Direction;
    protected Vector2 Position;
    protected Texture2D Texture;
    protected float Lifetime;
    public Rectangle Hitbox { get; set; }
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public void Update()
    {
        if (Lifetime <= 0)
        {
            CollisionManager.RemoveCollidable(this);
            return;
        }
        Position += Direction * Velocity * Globals.TotalSeconds;
    }
    
    public virtual void OnCollision(ICollidable collidable)
    {
    }
}