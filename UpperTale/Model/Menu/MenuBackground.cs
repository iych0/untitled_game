namespace Something.Model.Menu;

public class MenuBackground : Background 
{ 
    public MenuBackground()
    {
        Texture = Globals.Content.Load<Texture2D>("Textures/Backgrounds/MenuBackground");
    }
}