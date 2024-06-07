using System;
using System.Collections.Generic;
using Something.Interfaces;

namespace Something.Model.Game.HUD;

public class GameHud : IEntity, IDrawable
{
    private List<IDrawable> Elements { get; } = new()
    {
        new HealthBar(),
    };


    public void Draw()
    {
        foreach (var element in Elements)
        {
            element.Draw();
        }
    }

    public void Update()
    {
        foreach (var element in Elements)
        {
            element.Update();
        }
    }
}