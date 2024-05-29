using Microsoft.Xna.Framework;

namespace Something.Model.Interfaces;

public interface ICollidable
{
    Rectangle Hitbox { get; protected set; }
}