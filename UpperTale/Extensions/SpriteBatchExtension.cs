namespace Something.Extensions;

public static class SpriteBatchExtension
{
    public static void Draw(this SpriteBatch spriteBatch, string text, Vector2 position, Color color)
    {
        spriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Fonts/rfont"), text, position, color);
    }
}