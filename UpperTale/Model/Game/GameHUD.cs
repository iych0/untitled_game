namespace Something.Model.Game;

public class GameHud
{
    private Texture2D pixel = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
    
    //TODO Implement GameHud
    
    public GameHud()
    {
        pixel.SetData(new[] { Color.White });
    }
    
    
}