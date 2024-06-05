using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.Player;

public class DefaultProjectile : Projectile
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Textures/Projectiles/Projectile_Slime");
    
    public DefaultProjectile(Vector2 startPos)
    {
        Velocity = Config.DEFAULT_PROJECTILE_SPEED;
        Lifetime = Config.DEFAULT_PROJECTILE_LIFETIME;
        Direction = Vector2.Normalize(InputManager.MousePosition - startPos);
        Position = startPos;
        Texture = _texture;
        Hitbox = new Rectangle(Position.ToPoint(), _texture.Bounds.Size);
    }

    public override void OnCollision(ICollidable collidable)
    {
    }
}