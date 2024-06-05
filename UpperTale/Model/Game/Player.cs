using System;
using Something.Interfaces;
using Something.Managers;
using Something.Model.Game.NPCs;

namespace Something.Model.Game;

public class Player : IEntity, IDrawable, ICollidable
{
    private Vector2 _position;
    private static readonly Texture2D Texture = Globals.Content.Load<Texture2D>("sprites/Player/witch_animation");
    private const int MovementSpeed = Config.PLAYER_SPEED;
    private static readonly Vector2 PlayerSizeMult = new(Config.PLAYER_SIZE, Config.PLAYER_SIZE);
    private static readonly Point PlayerSize = new(42, 78);
    private static Vector2 _forbiddenDirection = new(2, 2);
    private const int FramesCount = 15;
    private Vector2? _bounceVector;
    public Rectangle Hitbox { get; set; }
    
    
    private readonly Texture2D _hitboxTexture;

    
    private readonly Animation _animation = new(Texture, FramesCount, 1, .05f, PlayerSizeMult);
    //private AnimationManager _animations = new();


    public Player(Vector2 position)
    {
        _position = position;
        Hitbox = new Rectangle(position.ToPoint(), PlayerSize);
        
        _hitboxTexture = new Texture2D(Globals.Graphics.GraphicsDevice, 1, 1);
        _hitboxTexture.SetData(new[] { Color.Red });
    }

    public void Update()
    {
        //TODO screen management in player class is not a good idea
        if (InputManager.Escape) GameManager.ChangeScreen("OptionsScreen");
        if (InputManager.Moving)
        {
            if (_bounceVector is not null)
            {
                _position -= Vector2.Normalize((Vector2)_bounceVector) * MovementSpeed * Globals.TotalSeconds;
                _bounceVector = null;
            }
            
            _position += Vector2.Normalize(InputManager.Direction) * MovementSpeed * Globals.TotalSeconds;
            Hitbox = new Rectangle(_position.ToPoint(), PlayerSize);
            _animation.Update();
        }
        else
        {
            _animation.Reset();
        }
        _forbiddenDirection = new Vector2(2, 2);
    }

    public void Draw()
    {
        _animation.Draw(_position);
        //Globals.SpriteBatch.Draw(_hitboxTexture, Hitbox, Color.White * 0.5f);
    }
    
    public void OnCollision(ICollidable collidable)
    {
        var npc = collidable as StaticNpc;
        var collisionVector = npc!.Position - _position;

        if (Math.Abs(collisionVector.X) > Math.Abs(collisionVector.Y))
            _bounceVector = collisionVector.X > 0 ? Vector2.UnitX : -Vector2.UnitX;
        else
            _bounceVector = collisionVector.Y > 0 ? Vector2.UnitY : -Vector2.UnitY;
    }
}