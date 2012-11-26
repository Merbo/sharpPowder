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
        Core core;

        public Element Element;
        public Vector2 Velocity;
        public Vector2 Position;
        /// <summary>
        /// True = when the particle hits the edge of the screen, bring it back and stop it from moving further
        /// False = when the particle hits the edge of the screen, kill it
        /// </summary>
        public bool boundaryBlock;

        public Particle(Element element, int x, int y, Core c)
        {
            this.core = c;
            this.Texture = Core.SolidTwoByTwo;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;

            this.boundaryBlock = true;
        }

        public Particle(Element element, int x, int y, float speedX, float speedY, Core c)
        {
            this.core = c;
            this.Texture = Core.SolidTwoByTwo;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);

            this.boundaryBlock = true;
        }

        public void Update(GameTime GameTime)
        {
            this.Position +=
                this.Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;

            if (this.Position.X > core.GraphicsDevice.Viewport.Width - this.Texture.Width)
            {
                if (this.boundaryBlock)
                {
                    this.Position.X = core.GraphicsDevice.Viewport.Width - this.Texture.Width;
                    this.Velocity.X = 0;
                }
                else
                    this.core.particleMap.RemoveParticle(this);
            }
            else if (this.Position.X < 0)
            {
                if (this.boundaryBlock)
                {
                    this.Position.X = 0;
                    this.Velocity.X = 0;
                }
                else
                    this.core.particleMap.RemoveParticle(this);
            }

            if (this.Position.Y > core.GraphicsDevice.Viewport.Height - this.Texture.Height)
            {
                if (this.boundaryBlock)
                {
                    this.Position.Y = core.GraphicsDevice.Viewport.Height - this.Texture.Height;
                    this.Velocity.Y = 0;
                }
                else
                    this.core.particleMap.RemoveParticle(this);
            }
            else if (this.Position.Y < 0)
            {
                if (this.boundaryBlock)
                {
                    this.Position.Y = core.Window.ClientBounds.Height;
                    this.Velocity.Y = 0;
                }
                else
                    this.core.particleMap.RemoveParticle(this);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
        }
    }
}
