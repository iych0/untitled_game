namespace Something.Interfaces;

public interface ICollidable
{
    Rectangle Hitbox { get; protected internal set;}
    void OnCollision(ICollidable collidable);
}