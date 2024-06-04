using Something.Interfaces;

namespace Something.Model.Game;

public abstract class StaticNpc : IEntity, IDrawable
{
    protected Vector2 Position;
    protected Texture2D Texture;

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public void Update()
    {
    }
    
    public void OnCollision(ICollidable collidable)
    {
        throw new System.NotImplementedException();
    }
}