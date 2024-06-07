namespace Something;

public static class Config
{
    //Global configs
    
        //Game config
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 1024;
        public const float SCREEN_ZOOM = 1f;
        public const int ANIMATION_CYCLE_TIME = 1;
        
        //Map config
        public const int MAP_PLAYABLE_ZONE_WIDTH = 800;
        public const int MAP_PLAYABLE_ZONE_HEIGHT = 800;
        
        //QuadTree config
        public const int QT_MAX_OBJECTS = 25;
        public const int QT_MAX_LEVELS = 5;
        
    
        
    //Player configs
    
        //Player
        public const int PLAYER_SPEED = 200;
        public const float PLAYER_SIZE = 1f;
        public const int PLAYER_DEFAULT_HEALTH = 100;
        public const float PLAYER_PROJECTILE_COOLDOWN = 0.5f;
        
        //DefaultProjectile
        public const int DEFAULT_PROJECTILE_SPEED = 10;
        public const float DEFAULT_PROJECTILE_TARGET_SPEED = 600;
        public const float DEFAULT_PROJECTILE_ACCELERATION = 10f;
        public const int DEFAULT_PROJECTILE_DAMAGE = 10;
        public const float DEFAULT_PROJECTILE_LIFETIME = 4f;
        
    
    //NPC configs
    
        //Slime
        public const int SLIME_HEALTH = 25;
        public const int SLIME_MOVEMENT_SPEED = 30;
        public const int SLIME_SIZE = 1;
        public const int SLIME_COLLISION_DAMAGE = 20;

}