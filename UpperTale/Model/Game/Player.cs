using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game;

public class Player : IEntity, IDrawable, ICollidable
{
    private Vector2 _position;
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch_spritesheet");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSize = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    private bool _isBlocked = false;
    private Vector2 _lastDirection = Vector2.Zero;
    public Rectangle Hitbox { get; set; }

    private readonly Animation _animation = new(Texture, 4, 1, 1f, PlayerSize);
    //private AnimationManager _animations = new();


    public Player(Vector2 position)
    {
        _position = position;
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
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
                Hitbox = new Rectangle(_position.ToPoint(), Texture.Bounds.Size);
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