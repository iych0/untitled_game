using System.Collections.Generic;
using Something.Model.Interfaces;

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