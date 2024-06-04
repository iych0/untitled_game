namespace Something;

public static class Config
{
    //Game config
    public const int SCREEN_WIDTH = 1280;
    public const int SCREEN_HEIGHT = 1024;
    public const float SCREEN_ZOOM = 1f;
    
    //Map config
    public const int MAP_TILES_WIDTH = 10;
    public const int MAP_TILES_HEIGTH = 10;
    public const int TILE_SIZE = 64;

    public const int MAP_PLAYABLE_ZONE_WIDTH = 800;
    public const int MAP_PLAYABLE_ZONE_HEIGHT = 800;
    
    //Player config
    public const int PLAYER_SPEED = 200;
    public const float PLAYER_SIZE = 1f;
    
    //QuadTree config
    public const int QT_MAX_OBJECTS = 25;
    public const int QT_MAX_LEVELS = 5;
}