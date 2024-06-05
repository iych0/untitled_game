using Something.Interfaces;
using Something.Managers;

namespace Something.Model.Game.NPCs;

public sealed class Slime : MovingNpc
{
    private readonly Texture2D _texture =
        Globals.Content.Load<Texture2D>("Sprites/NPCs/super_huge_slime_test");
    private readonly Animation _animation;
    private const int Frames = 1;
    private Vector2? _bounceVector;

    public Slime(Vector2 position)
    {
        Position = position;
        Texture = Globals.Content.Load<Texture2D>("Sprites/NPCs/super_huge_slime_test");
        Hitbox = new Rectangle(position.ToPoint(), Texture.Bounds.Size);
        MovementSpeed = Config.SLIME_MOVEMENT_SPEED;
        _animation = new Animation(_texture, Frames,
            1, 
            Config.ANIMATION_FRAMERATE/Frames,
            new Vector2(Config.SLIME_SIZE));
    }
    public override void Update()
    {
        if (_bounceVector is not null)
        {
            Position += Vector2.Normalize((Vector2)_bounceVector) * MovementSpeed * Globals.TotalSeconds;
            _bounceVector = null;
        }
        var direction = Vector2.Normalize(Player.Position - Position);
        Hitbox = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);
        Position += direction * MovementSpeed * Globals.TotalSeconds;
        
        _animation.Update();
    }
    
    public override void Draw()
    {
        _animation.Draw(Position);
    }
    
    public override void OnCollision(ICollidable collidable)
    {
        _bounceVector = collidable is not Npc npc ? CollisionManager.GetBounceVector(this) : 
            CollisionManager.GetBounceVector(this, npc);
    }
}