using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sharpPowder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace sharpPowder.Physics
{
    public class PhysicsCore
    {
        /// <summary>
        /// Air density at 0C
        /// </summary>
        public const float AirDensity = 1.2922f;
        public static bool GravityEnabled = true;


        public static void ApplyPhysics(List<Particle> input, GameTime GameTime)
        {
            foreach (Particle Particle in input)
            {
                if (GravityEnabled)
                    Gravity.ApplyGravity(Particle);

                Particle.Update(GameTime);
            }
        }
    }
}
