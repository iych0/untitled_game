using System;
using System.Collections.Generic;
using Something.Model;

namespace Something.Managers;

public class AnimationManager
{
    private readonly Dictionary<object, Animation> _anims = new();
    private object _lastKey;

    public AnimationManager(Texture2D texture, int[] rowIndexes, int framesX, int framesY, float size)
    {
        var keymap = CreateAnimationsKeymap(rowIndexes);
        foreach (var pair in keymap)
            AddAnimation(pair.Key, new Animation(texture,
                framesX,
                framesY,
                Config.ANIMATION_CYCLE_TIME * 1f / framesX,
                new Vector2(size),
                pair.Value));
    }

    private void AddAnimation(object key, Animation animation)
    {
        _anims.Add(key, animation);
        _lastKey ??= key;
    }
    
    //TODO fix idle animations
    public void Update(object key)
    {
        if (_anims.TryGetValue(key, out var value))
        {
            value.Start();
            _anims[key].Update();
            _lastKey = key;
        }
        else
        {
            _anims[_lastKey].Update();
        }
    }

    public void Draw(Vector2 position)
    {
        _anims[_lastKey].Draw(position);
    }

    private static Dictionary<Vector2, int> CreateAnimationsKeymap(int[] rowIndexes)
    {
        var keymap = new Dictionary<Vector2, int>();
        for (var i = 0; i < rowIndexes.Length; i++)
        {
            if (rowIndexes[i] != 0)
                // ReSharper disable once PossibleLossOfFraction
                keymap.Add(new Vector2(i % 3 - 1, i / 3 - 1), rowIndexes[i]);
        }

        return keymap;
    }

    public static Vector2 RoundDirection(Vector2 direction)
    {
        return new Vector2((float)Math.Round(direction.X), (float)Math.Round(direction.Y));
    }
}