using Something.Interfaces;

namespace Something.Model.Game.NPCs;

public sealed class Truffle : StaticNpc, ICollidable
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Sprites/NPCs/Truffle_test");
    private readonly Texture2D _hitboxTexture;
    
    public Truffle(Vector2 position)
    {
        Position = position;
        Texture = _texture;
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
        
        _hitboxTexture = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
        _hitboxTexture.SetData(new[] { Color.Red });
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Hitbox, Color.White);
        Globals.SpriteBatch.Draw(_hitboxTexture, Hitbox, Color.White);
    }
    
    public new void OnCollision(ICollidable collidable)
    {
    }
}