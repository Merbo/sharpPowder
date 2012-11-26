using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sharpPowder
{
    public class ParticleMap
    {
        public List<Particle> Particles;

        public ParticleMap()
        {
            Particles = new List<Particle>();
        }

        public void AddParticle(Particle part)
        {
            this.Particles.Add(part);
        }

        public void RemoveParticle(Particle part)
        {
            this.Particles.Remove(part);
        }

        public Particle GetParticleAt(int X, int Y)
        {
            foreach (Particle part in this.Particles)
            {
                if (Convert.ToInt32(part.Position.X) == X && Convert.ToInt32(part.Position.Y) == Y)
                    return part;
            }
            return null;
        }
    }
}
