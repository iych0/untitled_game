using Microsoft.Xna.Framework.Input;

namespace Something.Managers;

public static class InputManager
{
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static Vector2 Direction { get; private set; } = Vector2.Zero;
    public static bool Moving => Direction != Vector2.Zero;
    public static bool Action => Keyboard.GetState().IsKeyDown(Keys.Space);
    public static bool Escape => Keyboard.GetState().IsKeyDown(Keys.Escape);
    public static bool Shift => Keyboard.GetState().IsKeyDown(Keys.LeftShift);
    public static bool LeftClick => Mouse.GetState().LeftButton == ButtonState.Pressed;
    
    public static void Update()
    {
        Direction = Vector2.Zero;
        var keyboardState = Keyboard.GetState();

        if (keyboardState.GetPressedKeyCount() <= 0) return;
        if (keyboardState.IsKeyDown(Keys.A)) Direction = Direction with { X = -1 };
        if (keyboardState.IsKeyDown(Keys.D)) Direction = Direction with { X = 1 };
        if (keyboardState.IsKeyDown(Keys.W)) Direction = Direction with { Y = -1 };
        if (keyboardState.IsKeyDown(Keys.S)) Direction = Direction with { Y = 1 };
    }
}