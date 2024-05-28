using System;

namespace Something.Generators;

public class MapGenerator
{
    private readonly int _width;
    private readonly int _height;
    private readonly int[,] _map;
    private readonly Random _random = new();

    public MapGenerator(int width, int height)
    {
        _width = width;
        _height = height;
        _map = new int[width, height];
    }

    public int[,] GenerateMap()
    {
        for (int x = 0; x < _width; x++)
        for (int y = 0; y < _height; y++)
            _map[x, y] = 1;
        
        var startX = _random.Next(_width);
        var startY = _random.Next(_height);
        _map[startX, startY] = 0;
        
        var walker = new Walker(startX, startY);
        
        for (int i = 0; i < _width * _height; i++)
        {
            walker.Move(_random);
            if (walker.X >= 0 && walker.X < _width && walker.Y >= 0 && walker.Y < _height)
            {
                _map[walker.X, walker.Y] = 0;
            }
        }

        return _map;
    }
}

public class Walker
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Walker(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void Move(Random random)
    {
        var direction = random.Next(4);
        switch (direction)
        {
            case 0: // Up
                Y--;
                break;
            case 1: // Down
                Y++;
                break;
            case 2: // Left
                X--;
                break;
            case 3: // Right
                X++;
                break;
        }
    }
}