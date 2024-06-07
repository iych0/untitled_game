namespace Something.Model.Game.Map;

public class BoulderSmall : Obstacle
{
    public BoulderSmall(Vector2 position) : base(position)
    {
        _texture2D = Globals.Content.Load<Texture2D>("Textures/Obstacles/BoulderSmol");
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, _texture2D.Width, _texture2D.Height);
    }
}