namespace Something;

public class Debug
{
    public static readonly Texture2D Pixel = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);

    public static void Init()
    {
        Pixel.SetData(new [] {Color.White});
    }

    public static void DrawHitbox(Rectangle rectangle)
    {
        Globals.SpriteBatch.Draw(Pixel, rectangle, Color.Red * 0.5f);
    }
}