using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace sharpPowder
{
    public class Particle : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D Texture;
        Color Color;

        public Element Element;
        public Vector2 Velocity;
        public Vector2 Position;
        ContentManager Content;       

        public Particle(Element element, int x, int y, Game game)
            : base(game)
        {
            this.Content = game.Content;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            DrawOrder = 1000;
        }

        public Particle(Element element, int x, int y, float speedX, float speedY, Game game)
            : base(game)
        {
            this.Content = game.Content;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
            this.Velocity = new Vector2(speedX, speedY);
            DrawOrder = 1000;
        }

        public override void Update(GameTime GameTime)
        {
            this.Position +=
                this.Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Texture = Content.Load<Texture2D>("SolidTwoByTwo");
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.Texture, this.Position, this.Color);
            this.spriteBatch.End();
        }
    }
}
