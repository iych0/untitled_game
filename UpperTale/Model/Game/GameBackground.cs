using Microsoft.Xna.Framework.Graphics;

namespace Something.Model.Game;

public class GameBackground : IDrawable
{
    private readonly Texture2D _texture = Globals.Content.Load<Texture2D>("Textures/Backgrounds/GameBackground");
    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Vector2.Zero, Color.White);
    }

    public void Update()
    {
    }
}