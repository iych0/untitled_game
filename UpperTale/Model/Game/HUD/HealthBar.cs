using Something.Extensions;
using Something.Helpers;
using Something.Interfaces;

namespace Something.Model.Game.HUD;

public class HealthBar : IEntity, IDrawable
{
    private readonly Texture2D _pixel = DrawTools.Pixel;
    private readonly Point _healthBarPosition = new(30, 30);
    private readonly int _healthBarSize = 2;
    private Rectangle HealthBarBorder { get; }
    
    public HealthBar()
    {
        _pixel.SetData(new [] { Color.White });
       HealthBarBorder = new Rectangle(
           _healthBarPosition, 
           new Point(160 * _healthBarSize, 20 * _healthBarSize));
    }
    public void Draw()
    {
        Globals.SpriteBatch.Draw(_pixel, HealthBarBorder, Color.White);
        for (var i = 0; i < Player.Player.Health / 10; i++)
        {
            var pos = new Rectangle(
                _healthBarPosition.X + 2 * _healthBarSize + i * 16 * _healthBarSize,
                _healthBarPosition.Y + 2 * _healthBarSize, 
                8 * _healthBarSize,
                16 * _healthBarSize);
            Globals.SpriteBatch.Draw(_pixel, pos, Color.Red);
        Globals.SpriteBatch.Draw("Health", new Vector2(30 , HealthBarBorder.Y + _healthBarPosition.Y * 2), Color.White);
        }
    }

    public void Update()
    {
    }
}