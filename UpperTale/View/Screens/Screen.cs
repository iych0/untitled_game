using System.Collections.Generic;

namespace Something.View.Screens;

public abstract class Screen
{
    protected List<IDrawable> Entities;
    public abstract void Initialize();
    public void UpdateEntities()
    {
        foreach (var entity in Entities)
        {
            entity.Update();
        }
    }

    public void DrawEntities()
    {
        foreach (var entity in Entities)
        {
            entity.Draw();
        }
    }
}