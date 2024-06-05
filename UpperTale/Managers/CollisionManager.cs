using System;
using System.Collections.Generic;
using System.Linq;
using Something.Interfaces;
using Something.Model.Game;
using Something.Model.Game.NPCs;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Something.Managers;

public class CollisionManager
{
    private readonly QuadTree _quadtree;
    private static List<ICollidable> Collidables { get; } = new();
    
    public CollisionManager(Rectangle screenBounds)
    {
        _quadtree = new QuadTree(0, screenBounds);
    }
    
    public void CheckCollision()
    {
        _quadtree.Clear();

        foreach (var collidable in Collidables)
        {
            _quadtree.Insert(collidable);
        }

        foreach (var collidable in Collidables)
        {
            var collisions = _quadtree.Retrieve(new List<ICollidable>(), collidable);
            foreach (var collision in collisions.Where(
                         collision => collision != collidable && collision.Hitbox.Intersects(collidable.Hitbox)))
            {
                collidable.OnCollision(collision);
            }
        }
    }
    
    public static void AddCollidable(ICollidable collidable) => Collidables.Add(collidable);

    public static Vector2 GetBounceVector(Npc npc)
    {
        var collisionVector = npc!.Position - Player.Position;

        if (Math.Abs(collisionVector.X) > Math.Abs(collisionVector.Y))
            return collisionVector.X > 0 ? Vector2.UnitX : -Vector2.UnitX;
        return collisionVector.Y > 0 ? Vector2.UnitY : -Vector2.UnitY;
    }
    public static Vector2 GetBounceVector(Npc npc1, Npc npc2)
    {
        var collisionVector = npc1!.Position - npc2.Position;

        if (Math.Abs(collisionVector.X) > Math.Abs(collisionVector.Y))
            return collisionVector.X > 0 ? Vector2.UnitX : -Vector2.UnitX;
        return collisionVector.Y > 0 ? Vector2.UnitY : -Vector2.UnitY;
    }
}