using System.Collections.Generic;
using Something.Interfaces;

namespace Something.Model.Game;

public class QuadTree
{
    private const int MaxObjects = Config.QT_MAX_OBJECTS;
    private const int MaxLevels = Config.QT_MAX_LEVELS;

    private readonly int _level;
    private readonly List<ICollidable> _objects;
    private readonly Rectangle _bounds;
    private readonly QuadTree[] _nodes;

    public QuadTree(int level, Rectangle bounds)
    {
        _level = level;
        _objects = new List<ICollidable>();
        _bounds = bounds;
        _nodes = new QuadTree[4];
    }

    public void Clear()
    {
        _objects.Clear();

        for (var i = 0; i < _nodes.Length; i++)
        {
            if (_nodes[i] == null) continue;
            _nodes[i].Clear();
            _nodes[i] = null;
        }
    }

    private void Split()
    {
        var subWidth = _bounds.Width / 2;
        var subHeight = _bounds.Height / 2;
        var x = _bounds.X;
        var y = _bounds.Y;

        _nodes[0] = new QuadTree(_level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
        _nodes[1] = new QuadTree(_level + 1, new Rectangle(x, y, subWidth, subHeight));
        _nodes[2] = new QuadTree(_level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
        _nodes[3] = new QuadTree(_level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
    }

    private int GetIndex(ICollidable pRect)
    {
        var index = -1;
        double verticalMidpoint = _bounds.X + _bounds.Width / 2;
        double horizontalMidpoint = _bounds.Y + _bounds.Height / 2;

        var topQuadrant = pRect.Hitbox.Y < horizontalMidpoint && pRect.Hitbox.Y + pRect.Hitbox.Height < horizontalMidpoint;
        var bottomQuadrant = pRect.Hitbox.Y > horizontalMidpoint;

        if (pRect.Hitbox.X < verticalMidpoint && pRect.Hitbox.X + pRect.Hitbox.Width < verticalMidpoint)
        {
            if (topQuadrant)
            {
                index = 1;
            }
            else if (bottomQuadrant)
            {
                index = 2;
            }
        }
        else if (pRect.Hitbox.X > verticalMidpoint)
        {
            if (topQuadrant)
            {
                index = 0;
            }
            else if (bottomQuadrant)
            {
                index = 3;
            }
        }

        return index;
    }

    public void Insert(ICollidable pRect)
    {
        if (_nodes[0] != null)
        {
            var index = GetIndex(pRect);

            if (index != -1)
            {
                _nodes[index].Insert(pRect);

                return;
            }
        }

        _objects.Add(pRect);

        if (_objects.Count <= MaxObjects || _level >= MaxLevels) return;
        {
            if (_nodes[0] == null)
            {
                Split();
            }

            var i = 0;
            while (i < _objects.Count)
            {
                var index = GetIndex(_objects[i]);
                if (index != -1)
                {
                    _nodes[index].Insert(_objects[i]);
                    _objects.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public List<ICollidable> Retrieve(List<ICollidable> returnObjects, ICollidable pRect)
    {
        var index = GetIndex(pRect);
        if (index != -1 && _nodes[0] != null)
        {
            _nodes[index].Retrieve(returnObjects, pRect);
        }

        returnObjects.AddRange(_objects);

        return returnObjects;
    }
}