using Microsoft.Xna.Framework.Graphics;

namespace Something.Model.Game;

public class GameBackground : Background
{
        public GameBackground()
        {
                Texture = Globals.Content.Load<Texture2D>("Textures/Backgrounds/GameBackground");
        }
}