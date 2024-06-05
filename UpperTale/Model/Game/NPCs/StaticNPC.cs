using Something.Interfaces;

namespace Something.Model.Game.NPCs;

public abstract class StaticNpc : IEntity, IDrawable, ICollidable
{
    protected Texture2D Texture;
    public Rectangle Hitbox { get; set; }
    
    public Vector2 Position { get; protected set; }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Hitbox, Color.White);
    }

    public void Update()
    {
    }
    
    public void OnCollision(ICollidable collidable)
    {
    }
}