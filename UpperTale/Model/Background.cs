using Microsoft.Xna.Framework.Graphics;

namespace Something.Model;

public abstract class Background : IDrawable
{
    protected Texture2D Texture;
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
    }

    public void Update()
    {
    }
}