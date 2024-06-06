using System.Collections.Generic;
using Something.Interfaces;
using Something.Managers;
using Something.Model.Game.NPCs;

namespace Something.Model.Game.Player;

public class Player : IEntity, IDrawable, ICollidable
{
    public static Vector2 Position { get; private set; }
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch_spritesheet");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSizeMult = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    private static readonly Point PlayerSize = new(42, 78);
    private const int Frames = 15;
    public int Health { get; private set; } = Config.PLAYER_DEFAULT_HEALTH;
    private static float ProjectileTimer { get; set; } = Config.PLAYER_PROJECTILE_COOLDOWN;
    private Vector2? _bounceVector;
    public Rectangle Hitbox { get; set; }
    
    private readonly Animation _animation = new(Texture, Frames, 1, .05f, PlayerSizeMult);
    
    private readonly Dictionary<Vector2, int> _animationKeys = 
        AnimationManager.CreateAnimationsKeymap(new[] { 
            3, 0, 2, 
            3, 1, 2,
            3, 0, 2 });
    
    private AnimationManager _animationManager = new();
    
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
            _animation.Update();
        }
        else
        {
            _animation.Reset();
        }
        ProjectileTimer -= Globals.TotalSeconds;
    }

    public void Draw()
    {
        _animation.Draw(Position);
    }
    
    public void OnCollision(ICollidable collidable)
    {
        if (collidable is Projectile projectile)
        {
            if (projectile.Owner == this) return;
            Health -= (int)projectile.Damage;
            return;
        };
        var npc = collidable as Npc;
        _bounceVector = CollisionManager.GetBounceVector(npc);
    }
    
    private void ConstructAnimation(Vector2 key, int row)
    {
        _animationManager.AddAnimation(key,
            new Animation(Texture,
                13,
                3,
                Config.ANIMATION_CYCLE_TIME * 1f/ Frames,
                new Vector2(Config.PLAYER_SIZE), row));
    }
}