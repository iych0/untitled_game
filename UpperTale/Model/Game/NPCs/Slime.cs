using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.NPCs;

public sealed class Slime : MovingNpc
{
    private readonly Point _spriteSize;

    private readonly AnimationManager _animationManager;
    private Vector2 _direction;
    private const int FramesX = 8;
    private const int FramesY = 4;
    private readonly int[] _animationKeys =
    {
        2, 4, 3,
        2, 1, 3,
        2, 4, 3
    };
    private Vector2? _bounceVector;
    private const int BounceMult = 30;
    private bool _isCollidablePlayer;

    public Slime(Vector2 position)
    {
        Position = position;
        Texture = Globals.Content.Load<Texture2D>("Sprites/NPCs/slime_spritesheet");
        _spriteSize = new Point(Texture.Width / FramesX, Texture.Height / FramesY);
        Hitbox = new Rectangle(position.ToPoint(), _spriteSize);
        MovementSpeed = Config.SLIME_MOVEMENT_SPEED;
        Health = Config.SLIME_HEALTH;
        CollisionDamage = Config.SLIME_COLLISION_DAMAGE;
        _animationManager = new AnimationManager(Texture, _animationKeys, FramesX, FramesY, Config.SLIME_SIZE);
    }
    public override void Update()
    {
        base.Update();
        if (_bounceVector is not null)
        {
            var bounceForce = _isCollidablePlayer ? BounceMult : 1;
            Position += Vector2.Normalize((Vector2)_bounceVector) * MovementSpeed * Globals.TotalSeconds * bounceForce;
            _bounceVector = null;
            _isCollidablePlayer = false;
        }
        _direction = Vector2.Normalize(Player.Player.Position - Position);
        Hitbox = new Rectangle(Position.ToPoint(), _spriteSize);
        Position += _direction * MovementSpeed * Globals.TotalSeconds;

        _animationManager.Update(AnimationManager.RoundDirection(_direction));
    }
    
    public override void Draw()
    {
        _animationManager.Draw(Position);
        Debug.DrawHitbox(Hitbox);
    }
    
    public override void OnCollision(ICollidable collidable)
    {
        if (collidable is Projectile projectile && projectile.Owner.GetType() == typeof(Player.Player))
        {
            Health -= projectile.Damage;
            return;
        }
        if (collidable.GetType() == typeof(Player.Player)) _isCollidablePlayer = true;
        _bounceVector = collidable is not Npc npc ? CollisionManager.GetBounceVector(this) : 
            CollisionManager.GetBounceVector(this, npc);
    }
}