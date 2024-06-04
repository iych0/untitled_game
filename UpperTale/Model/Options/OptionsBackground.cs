namespace Something.Model.Options;

public class OptionsBackground : IDrawable
{
    private Texture2D _texture = Globals.Content.Load<Texture2D>("Textures/Backgrounds/MenuBackground");

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Vector2.Zero, Color.White);
    }

    public void Update()
    {
    }
}