using System.Collections.Generic;
using Something.Interfaces;

namespace Something.View.Screens;

public abstract class Screen
{
    protected List<IDrawable> Entities;
    private readonly List<IDrawable> _entitiesToDelete = new();
    public abstract void Initialize();
    public virtual void UpdateEntities()
    {
        foreach (var condemned in _entitiesToDelete)
            Entities.Remove(condemned);
        
        _entitiesToDelete.Clear();
        
        foreach (var entity in Entities)
            entity.Update();
    }

    public void DrawEntities()
    {
        foreach (var entity in Entities)
            entity.Draw();
    }
    
    public void AnnihilateEntity(IEntity entity) =>
        _entitiesToDelete.Add((IDrawable)entity);
}