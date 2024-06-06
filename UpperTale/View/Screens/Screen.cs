using System.Collections.Generic;
using Something.Interfaces;

namespace Something.View.Screens;

public abstract class Screen
{
    protected List<IDrawable> Entities;
    protected readonly List<IDrawable> EntitiesToDelete = new();
    public abstract void Initialize();
    public void UpdateEntities()
    {
        foreach (var condemned in EntitiesToDelete)
            Entities.Remove(condemned);
        
        EntitiesToDelete.Clear();
        
        foreach (var entity in Entities)
            entity.Update();
    }

    public void DrawEntities()
    {
        foreach (var entity in Entities)
            entity.Draw();
    }
    
    public void AnnihilateEntity(IEntity entity) =>
        EntitiesToDelete.Add((IDrawable)entity);
}