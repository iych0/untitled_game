using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Something.Managers;
using Something.Model.Interfaces;
using IDrawable = Something.Model.Interfaces.IDrawable;

namespace Something.Model;

public class Player : IDrawable, IAnimatable
{
    private Vector2 _position;
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/fox_running");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSize = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    public Rectangle Hitbox { get; private set; }

    private readonly Animation _animation = new(Texture, 8, 1, 0.05f, PlayerSize);
    //private AnimationManager _animations = new();


    public Player(Vector2 position)
    {
        _position = position;
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
    }

    public void Update()
    {
        if (InputManager.Moving)
        {
            _position += Vector2.Normalize(InputManager.Direction) * MovementSpeed * Globals.TotalSeconds;
            Hitbox = new Rectangle(_position.ToPoint(), Texture.Bounds.Size);
            _animation.Update();
        }
        else
        {
            _animation.Reset();
        }
        
    }

    public void Draw()
    {
        _animation.Draw(_position);
    }
}