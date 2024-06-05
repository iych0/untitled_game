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
            new Player(new Vector2(600, 600)),
            new Slime(new Vector2(400, 400)),
            new Slime(new Vector2(500, 400)),
            new Slime(new Vector2(600, 400)),
            new Slime(new Vector2(400, 500)),
            new Slime(new Vector2(400, 600)),
            new Slime(new Vector2(700, 700)),
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