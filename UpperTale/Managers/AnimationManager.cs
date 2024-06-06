using System.Collections.Generic;
using Something.Model;

namespace Something.Managers;

public class AnimationManager
{
    private readonly Dictionary<object, Animation> _anims = new();
    private object _lastKey;

    public void AddAnimation(object key, Animation animation)
    {
        _anims.Add(key, animation);
        _lastKey ??= key;
    }

    public void Update(object key)
    {
        if (_anims.TryGetValue(key, out Animation value))
        {
            value.Start();
            _anims[key].Update();
            _lastKey = key;
        }
        else
        {
            _anims[_lastKey].Stop();
            _anims[_lastKey].Reset();
        }
    }

    public void Draw(Vector2 position)
    {
        _anims[_lastKey].Draw(position);
    }
    
    
    
    public static Dictionary<Vector2, int> CreateAnimationsKeymap(int[] rowIndexes)
    {
        var keymap = new Dictionary<Vector2, int>();
        for (var i = 0; i < rowIndexes.Length; i++)
        {
            if (rowIndexes[i] != 0)
            // ReSharper disable once PossibleLossOfFraction
                keymap.Add(new Vector2(i / 3 - 1, i % 3 - 1), rowIndexes[i]);
        }

        return keymap;
    }
}