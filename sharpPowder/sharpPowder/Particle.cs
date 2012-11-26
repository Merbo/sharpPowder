using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace sharpPowder
{
    public class Particle
    {
        Texture2D Texture;
        Color Color;

        public Element Element;
        public Vector2 Velocity;
        public Vector2 Position;

        public Particle(Element element, int x, int y)
        {
            this.Texture = Core.SolidTwoByTwo;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
        }

        public Particle(Element element, int x, int y, float speedX, float speedY)
        {
            this.Texture = Core.SolidTwoByTwo;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
        }

        public void Update(GameTime GameTime)
        {
            this.Position +=
                this.Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
        }
    }
}
