using System;
using System.Collections.Generic;
using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.NPCs;

public sealed class Slime : MovingNpc
{
    private readonly Dictionary<Vector2, int> _animationKeys = new()
    {
        { new Vector2(0, 0), 1 }, 
        { new Vector2(0, 1), 1 }, 
        { new Vector2(0, -1), 1 },
        { new Vector2(-1, -1), 2 },
        { new Vector2(-1, 0), 2 },
        { new Vector2(-1, 1), 2 },
        { new Vector2(1, -1), 3 },
        { new Vector2(1, 0), 3 },
        { new Vector2(1, 1), 3 }
    };

    private readonly AnimationManager _animationManager = new();
    private Vector2 _direction;
    private const int Frames = 1;
    private Vector2? _bounceVector;

    public Slime(Vector2 position)
    {
        Position = position;
        Texture = Globals.Content.Load<Texture2D>("Sprites/NPCs/slime_spritesheet");
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
        MovementSpeed = Config.SLIME_MOVEMENT_SPEED;
        foreach (var pair in _animationKeys)
            ConstructAnimation(pair.Key, pair.Value);
    }
    public override void Update()
    {
        if (_bounceVector is not null)
        {
            Position += Vector2.Normalize((Vector2)_bounceVector) * MovementSpeed * Globals.TotalSeconds;
            _bounceVector = null;
        }
        _direction = Vector2.Normalize(Player.Position - Position);
        Hitbox = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);
        Position += _direction * MovementSpeed * Globals.TotalSeconds;
        var roundedDirection = new Vector2((float)Math.Round(_direction.X), (float)Math.Round(_direction.Y));
        
        _animationManager.Update(roundedDirection);
    }
    
    public override void Draw()
    {
        _animationManager.Draw(Position);
    }
    
    public override void OnCollision(ICollidable collidable)
    {
        _bounceVector = collidable is not Npc npc ? CollisionManager.GetBounceVector(this) : 
            CollisionManager.GetBounceVector(this, npc);
    }

    private void ConstructAnimation(Vector2 key, int row)
    {
        _animationManager.AddAnimation(key,
            new Animation(Texture,
                3,
                3,
                Config.ANIMATION_FRAMERATE / Frames,
                new Vector2(Config.SLIME_SIZE), row));
    }
}