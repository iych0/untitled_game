using System.Collections.Generic;
using Something.Model.Game;

namespace Something.Managers;

public static class ProjectileManager
{
    private static readonly List<Projectile> Projectiles = new();
    private static readonly List<Projectile> ProjectilesToRemove = new();

    public static void AddProjectile(Projectile projectile)
    {
        lock (Projectiles)
        {
            Projectiles.Add(projectile);
        }

        CollisionManager.AddCollidable(projectile);
    }

    public static void RemoveProjectile(Projectile projectile)
    {
        ProjectilesToRemove.Add(projectile);
    }
    
    public static void Update()
    {
        foreach (var projectile in ProjectilesToRemove)
        {
            Projectiles.Remove(projectile);
            CollisionManager.RemoveCollidable(projectile);
        }
        ProjectilesToRemove.Clear();
        foreach (var projectile in Projectiles)
            projectile.Update();
    }
    
    public static void Draw()
    {
        foreach (var projectile in Projectiles)
            projectile.Draw();
    }
}