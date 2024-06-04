using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.NPCs;

public sealed class Truffle : StaticNpc, ICollidable
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Sprites/NPCs/Truffle_test");

    public Rectangle Hitbox { get; set; }
    public Truffle(Vector2 position)
    {
        Texture = _texture;
        Position = position;
        Hitbox = new Rectangle((int) Position.X, (int) Position.Y, _texture.Width, _texture.Height);
    }
    
    public new void OnCollision(ICollidable collidable)
    {
    }
}