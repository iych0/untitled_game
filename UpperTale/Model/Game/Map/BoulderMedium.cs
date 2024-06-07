namespace Something.Model.Game.Map;

public class BoulderMedium : Obstacle
{
    public BoulderMedium(Vector2 position) : base(position)
    {
        _texture2D = Globals.Content.Load<Texture2D>("Textures/Obstacles/BoulderMedium");
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, _texture2D.Width, _texture2D.Height);
    }
}