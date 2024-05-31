
using Something.Model.Interfaces;

namespace Something.Model.Game;

public class StaticNpc : IDrawable, IEntity
{
    Vector2 Position;
    Texture2D Texture;   
    public void Draw()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}