namespace Something.Model.Game;

public class Map : IDrawable
{
    private readonly Texture2D _texture2D = Globals.Content.Load<Texture2D>("Textures/Maps/IslandMap_1");
    
    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture2D, new Vector2(200, 100), 
            null,
            Color.White, 0f, Vector2.One, 1f, SpriteEffects.None, 0f);
    }

    public void Update()
    {
    }
}