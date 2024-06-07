using Something.Interfaces;
using Something.Managers;
using Something.Model.Game.NPCs;

namespace Something.Model.Game.Player;

public class Player : IEntity, IDrawable, ICollidable
{
    public static Vector2 Position { get; private set; }
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch_spritesheet");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Point PlayerSize = new(Texture.Bounds.Size.X / FramesX, Texture.Bounds.Size.Y / FramesY);
    private const int FramesX = 13;
    private const int FramesY = 3;
    public static int Health { get; private set; } = Config.PLAYER_DEFAULT_HEALTH;
    private static float ProjectileTimer { get; set; } = Config.PLAYER_PROJECTILE_COOLDOWN;
    private Vector2? _bounceVector;
    public Rectangle Hitbox { get; set; }
    
    //private readonly Animation _animation = new(Texture, Frames, 1, .05f, PlayerSizeMult);
    private readonly AnimationManager _animationManager = 
        new(Texture, AnimationKeys, FramesX, FramesY, Config.PLAYER_SIZE);
    
    private static readonly int[] AnimationKeys = { 
        3, 0, 2, 
        3, 1, 2,
        3, 0, 2 };
    
    public Player(Vector2 position)
    {
        Position = position;
        Hitbox = new Rectangle(position.ToPoint(), PlayerSize);
    }
    
    private void FireProjectile()
    {
        ProjectileTimer = Config.PLAYER_PROJECTILE_COOLDOWN;
        ProjectileManager.AddProjectile(new DefaultProjectile(Position, this));
    }

    public void Update()
    {
        //TODO screen management in player class is not a good idea
        if (InputManager.Escape) GameManager.ChangeScreen("OptionsScreen");
        if (InputManager.LeftClick && ProjectileTimer <= 0) FireProjectile();
        if (InputManager.Moving)
        {
            if (_bounceVector is not null)
            {
                Position -= Vector2.Normalize((Vector2)_bounceVector) * MovementSpeed * Globals.TotalSeconds;
                _bounceVector = null;
            }
            
            Position += Vector2.Normalize(InputManager.Direction) * MovementSpeed * Globals.TotalSeconds;
            Hitbox = new Rectangle(Position.ToPoint(), PlayerSize);
            _animationManager.Update(InputManager.Direction);
        }
        ProjectileTimer -= Globals.TotalSeconds;
    }

    public void Draw()
    {
        _animationManager.Draw(Position);
        Debug.DrawHitbox(Hitbox);
    }
    
    public void OnCollision(ICollidable collidable)
    {
        if (collidable is Projectile projectile)
        {
            if (projectile.Owner == this) return;
            Health -= projectile.Damage;
            return;
        }
        var npc = collidable as Npc;
        _bounceVector = CollisionManager.GetBounceVector(npc);
    }
}