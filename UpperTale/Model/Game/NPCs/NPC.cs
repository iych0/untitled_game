using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.NPCs;

public abstract class Npc : IEntity, IDrawable, ICollidable
{
    protected Texture2D Texture;
    protected int Health;
    public Vector2 Position { get; protected set; }
    public Rectangle Hitbox { get; set; }
    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public virtual void Update()
    {
        if (Health <= 0)
            GameManager.AnnihilateEntity(this);
    }
    
    public virtual void OnCollision(ICollidable collidable)
    {
    }
}