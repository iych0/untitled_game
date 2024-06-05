using Something.Interfaces;
using Something.Managers;
using Something.Model.Game.NPCs;

namespace Something.Model.Game.Player;

public class Player : IEntity, IDrawable, ICollidable
{
    public static Vector2 Position { get; private set; }
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch_animation");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSizeMult = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    private static readonly Point PlayerSize = new(42, 78);
    private const int FramesCount = 15;
    private Vector2? _bounceVector;
    public Rectangle Hitbox { get; set; }
    
    private readonly Animation _animation = new(Texture, FramesCount, 1, .05f, PlayerSizeMult);
    //private AnimationManager _animations = new();

    //TODO Create projectile manager
    public Player(Vector2 position)
    {
        Position = position;
        Hitbox = new Rectangle(position.ToPoint(), PlayerSize);
    }
    
    private static void FireProjectile()
    {
        
        CollisionManager.AddCollidable(new DefaultProjectile(Position));
    }

    public void Update()
    {
        //TODO screen management in player class is not a good idea
        if (InputManager.Escape) GameManager.ChangeScreen("OptionsScreen");
        if (InputManager.LeftClick) FireProjectile();
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
    }

    public void Draw()
    {
        _animation.Draw(Position);
    }
    
    public void OnCollision(ICollidable collidable)
    {
        if (collidable is Projectile) return;
        var npc = collidable as Npc;
        _bounceVector = CollisionManager.GetBounceVector(npc);
    }
}