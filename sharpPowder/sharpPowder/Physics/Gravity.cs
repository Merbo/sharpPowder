using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sharpPowder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sharpPowder.Physics
{
    public class Gravity
    {
        /// <summary>
        /// Gravitational constant on earth
        /// </summary>
        public const float gravConstant = 9.81f;

        public static void ApplyGravity(Particle Particle)
        {
            //http://upload.wikimedia.org/math/2/5/8/2584a12584dcea216e766c4bbcb514eb.png
            float DragCoefficient = Convert.ToSingle((2) / (Particle.Element.Density * Math.Pow(Particle.Velocity.Y, 2) * 1));

            if (Particle.Velocity.Y > 0)
                Particle.Velocity.Y *= -1;
            Particle.Velocity.Y *= gravConstant;

            Particle.Velocity.X *= (1 - Particle.Element.Friction);
        }
    }
}
