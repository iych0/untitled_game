using Something.Interfaces;

namespace Something.Model.Game.NPCs;

public sealed class Truffle : StaticNpc, ICollidable
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Sprites/NPCs/Truffle_test");
    
    public Truffle(Vector2 position)
    {
        Texture = _texture;
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
    }
    
    public new void OnCollision(ICollidable collidable)
    {
    }
}