using System.Collections.Generic;
using Something.Managers;

namespace Something.Model.Game.Map;

public class Obstacles : IDrawable
{
    private List<Obstacle> _obstacles;

    public Obstacles()
    {
        _obstacles = new List<Obstacle>
        {
            new BoulderLarge(new Vector2(750, 300)),
            new BoulderMedium(new Vector2(300, 525)),
            new BoulderSmall(new Vector2(800, 850)),
            new BoulderSmall(new Vector2(850, 850)),
            new BoulderSmall(new Vector2(830, 820))
        };

        foreach (var obstacle in _obstacles)
            CollisionManager.AddCollidable(obstacle);
    }

    public void Draw()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Draw();
        }
    }

    public void Update()
    {
    }
}