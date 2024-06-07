using Something.Helpers;
using Something.Interfaces;

namespace Something.Model.Game.Pause;

public class PauseBackground : IEntity, IDrawable
{
    private readonly Texture2D _pixel = DrawTools.Pixel;


    public void Draw()
    {
        _pixel.SetData(new[] { Color.White });
        Globals.SpriteBatch.Draw(
            _pixel, 
            new Rectangle(
                0, 0, 
                (int)Globals.ScreenSize.X, 
                (int)Globals.ScreenSize.Y), 
            Color.Black * 0.5f);
    }

    public void Update()
    {
    }
}