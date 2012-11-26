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
            this.Texture = Core.SolidPixel;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;

            this.boundaryBlock = true;
        }

        public Particle(Element element, int x, int y, float speedX, float speedY, Core c)
        {
            this.core = c;
            this.Texture = Core.SolidPixel;
            this.Color = element.Color;
            this.Element = element;

            this.Position = new Vector2(x, y);

            this.boundaryBlock = true;
        }

        /// <summary>
        /// Gets neighbors of particle.
        /// 
        /// Indices:
        /// 
        /// 0 1 2
        /// 3   4
        /// 5 6 7
        /// </summary>
        /// <returns>An array of the neighbors.</returns>
        public Particle[] getNeighbors()
        {
            int X = Convert.ToInt32(this.Position.X);
            int Y = Convert.ToInt32(this.Position.Y);
            Particle[] neighbors = new Particle[8];
            neighbors[0] = this.core.particleMap.GetParticleAt(X - 1, Y + 1);
            neighbors[1] = this.core.particleMap.GetParticleAt(X, Y + 1);
            neighbors[2] = this.core.particleMap.GetParticleAt(X + 1, Y + 1);
            neighbors[3] = this.core.particleMap.GetParticleAt(X - 1, Y);
            neighbors[4] = this.core.particleMap.GetParticleAt(X + 1, Y);
            neighbors[5] = this.core.particleMap.GetParticleAt(X - 1, Y - 1);
            neighbors[6] = this.core.particleMap.GetParticleAt(X, Y - 1);
            neighbors[7] = this.core.particleMap.GetParticleAt(X + 1, Y - 1);

            return neighbors;
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

            Particle[] neighbors = this.getNeighbors();
            if (neighbors[6] != null)
            {
                this.Velocity.Y = 0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
        }
    }
}
