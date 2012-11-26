using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sharpPowder
{
    public class Particle : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D Texture;
        Rectangle Rectangle;
        Color Color;

        public int X;
        public int Y;
        public Element Element;
        public Vector2 Velocity;

        public Particle(Element element, int x, int y, Game game)
            : base(game)
        {
            this.X = x;
            this.Y = y;
            this.Color = element.Color;
            this.Element = element;

            this.Rectangle = new Rectangle(this.X, this.Y, 2, 2);

            this.Velocity = Vector2.Zero;
            DrawOrder = 1000;
        }

        public Particle(Element element, int x, int y, float speedX, float speedY, Game game)
            : base(game)
        {
            this.X = x;
            this.Y = y;
            this.Color = element.Color;
            this.Element = element;

            this.Rectangle = new Rectangle(this.X, this.Y, 2, 2);

            this.Velocity = new Vector2(speedX, speedY);
            DrawOrder = 1000;
        }

        public void UpdateCoords(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Texture = new Texture2D(GraphicsDevice, 1, 1);
            this.Texture.SetData(new Color[] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.Texture, this.Rectangle, this.Color);
            this.spriteBatch.End();
        }
    }
}
