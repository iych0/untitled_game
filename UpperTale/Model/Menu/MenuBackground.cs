using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Something.Model.Interfaces.IDrawable;

namespace Something.Model.Menu;

public class MenuBackground : IDrawable
{
    private Texture2D _texture;
    
    public MenuBackground()
    {
        _texture = Globals.Content.Load<Texture2D>("Textures/Backgrounds/MenuBackground");
    }
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Vector2.Zero, Color.White);
    }

    public void Update()
    {
    }
}