using Something.Interfaces;

namespace Something.Model.Game.NPCs;

public abstract class Npc : IEntity, IDrawable, ICollidable
{
    protected Texture2D Texture;
    public Vector2 Position { get; protected set; }
    public Rectangle Hitbox { get; set; }
    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public abstract void Update();
    
    public virtual void OnCollision(ICollidable collidable)
    {
    }
}