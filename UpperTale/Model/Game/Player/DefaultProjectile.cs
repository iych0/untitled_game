using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.Player;

public class DefaultProjectile : Projectile
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Textures/Projectiles/Projectile_Slime");

    private const float TargetVelocity = Config.DEFAULT_PROJECTILE_TARGET_SPEED;
    private const float Acceleration = Config.DEFAULT_PROJECTILE_ACCELERATION;

    public DefaultProjectile(Vector2 startPos, IEntity owner)
    {
        Velocity = Config.DEFAULT_PROJECTILE_SPEED;
        Lifetime = Config.DEFAULT_PROJECTILE_LIFETIME;
        Direction = Vector2.Normalize(InputManager.MousePosition - startPos);
        Position = startPos;
        Texture = _texture;
        Hitbox = new Rectangle(Position.ToPoint(), _texture.Bounds.Size);
        Damage = Config.DEFAULT_PROJECTILE_DAMAGE;
        Owner = owner;
    }
    
    public override void Update()
    {
        base.Update();
        Velocity = MathHelper.SmoothStep(Velocity,
            TargetVelocity, 
            Acceleration * Globals.TotalSeconds);
    }
}