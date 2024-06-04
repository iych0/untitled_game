using Something.Interfaces;
using Something.Managers;
using Something.Model.Game.NPCs;

namespace Something.Model.Game;

public class Player : IEntity, IDrawable, ICollidable
{
    private Vector2 _position;
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSizeMult = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    private static readonly Point PlayerSize = new(17, 100);
    private bool _isBlocked;
    private Vector2 _lastDirection = Vector2.Zero;
    private const int FramesCount = 1;
    public Rectangle Hitbox { get; set; }

    private readonly Animation _animation = new(Texture, FramesCount, 1, 1f, PlayerSizeMult);
    //private AnimationManager _animations = new();


    public Player(Vector2 position)
    {
        _position = position;
        Hitbox = new Rectangle(position.ToPoint(), PlayerSize);
    }

    public void Update()
    {
        //TODO screen management in player class is not a good idea
        if (InputManager.Escape) GameManager.ChangeScreen("OptionsScreen");
        if (InputManager.Moving)
        {
            Vector2 direction = Vector2.Normalize(InputManager.Direction);
            if (!_isBlocked || direction != _lastDirection)
            {
                _position += Vector2.Normalize(InputManager.Direction) * MovementSpeed * Globals.TotalSeconds;
                Hitbox = new Rectangle(_position.ToPoint(), PlayerSize);
                _animation.Update();
                _lastDirection = direction;
            }
        }
        else
        {
            _animation.Reset();
        }
        
        _isBlocked = false;
    }

    public void Draw()
    {
        _animation.Draw(_position);
    }
    
    public void OnCollision(ICollidable collidable)
    {
        if (collidable is StaticNpc)
        {
            _isBlocked = true;
        }
    }
}