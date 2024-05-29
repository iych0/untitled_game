using System.Drawing;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Something.Managers;

public class CollisionManager
{
    private Rectangle _rectangle;
    
    
    private void CheckCollision()
    {
        _rectangle.Intersects(_rectangle);
    }
}