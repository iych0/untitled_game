using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game;

public abstract class Projectile : IEntity, IDrawable, ICollidable
{
    protected float Velocity;
    protected Vector2 Direction;
    protected Vector2 Position;
    protected Texture2D Texture;
    protected float Lifetime;
    public IEntity Owner { get; protected init; }
    public int Damage { get; protected set; }
    public Rectangle Hitbox { get; set; }
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
        Debug.DrawHitbox(Hitbox);
    }

    public virtual void Update()
    {
        if (Lifetime <= 0)
        {
            ProjectileManager.RemoveProjectile(this);
            return;
        }
        Lifetime -= Globals.TotalSeconds;
        
        Position += Direction * Velocity * Globals.TotalSeconds;
        Hitbox = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);
    }
    
    public virtual void OnCollision(ICollidable collidable)
    {
        if ((collidable is Player.Player player && player != Owner) ||
            (collidable is NPCs.Npc npc && npc != Owner))
            ProjectileManager.RemoveProjectile(this);
    }
}