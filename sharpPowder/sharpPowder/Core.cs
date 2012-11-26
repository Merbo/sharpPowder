using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using sharpPowder.Physics;

namespace sharpPowder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Core : Microsoft.Xna.Framework.Game
    {
        public List<Particle> ParticleMap;
        public static Texture2D SolidTwoByTwo;

        private static Element TestPowder_Element = new Element("Test Powder", "Powder test... Debug element.", Element.ElementType.Powder, Color.Blue, 1.1f, 0.2f, null);
        public Element[] TestElements = 
        {
            TestPowder_Element,
        };

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Core()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ParticleMap = new List<Particle>(this.Window.ClientBounds.Width * this.Window.ClientBounds.Height);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SolidTwoByTwo = Content.Load<Texture2D>("SolidTwoByTwo");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                ParticleMap.Add(new Particle(TestPowder_Element, Mouse.GetState().X, Mouse.GetState().Y));

            PhysicsCore.ApplyPhysics(ParticleMap, gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (Particle P in ParticleMap)
                P.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
