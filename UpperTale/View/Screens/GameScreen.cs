using System.Collections.Generic;
using Something.Interfaces;
using Something.Managers;
using Something.Model.Game;
using Something.Model.Game.NPCs;

namespace Something.View.Screens;

public class GameScreen : Screen
{
    public override void Initialize()
    {
        Entities = new List<IDrawable>
        {
            new GameBackground(),
            new Map(),
            new Player(Vector2.Zero),
            new Truffle(new Vector2(500, 500)),
        };
        AddToCollisionManager();
    }
    
    private void AddToCollisionManager()
    {
        foreach (var entity in Entities)
        {
            if (entity is ICollidable collidable)
            {
                CollisionManager.AddCollidable(collidable);
            }
        }
    }
}