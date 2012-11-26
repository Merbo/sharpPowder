using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework;

namespace sharpPowder
{
    public class Element
    {
        public string Name;
        public string Description;
        public ElementType Type;
        public Color Color;
        public float Density;
        public float Friction;
        public Delegate UpdateMethod;

        /// <summary>
        /// Creates a new element with the necessary parameters.
        /// </summary>
        /// <param name="name">The name of the element to show to clients.</param>
        /// <param name="description">The description of the element to show to clients.</param>
        /// <param name="type">The ElementType type of the element.</param>
        /// <param name="color">The color of the element.</param>
        /// <param name="mass">The mass of the element (grams)</param>
        /// <param name="density">The density of the element. (grams/cm²)</param>
        /// <param name="updateMethod">
        /// A method (byte) called whenever the element should update itself.
        /// Method:
        /// byte 
        /// Should return depending on the following things:
        /// Return 0 = Do default action
        /// Return 1 = Delete me
        /// More return types may be added soon.
        /// </param>
        public Element(string name, string description, ElementType type, Color color, float density, float friction, Delegate updateMethod)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Color = color;
            this.Density = density;
            this.Friction = friction;
            this.UpdateMethod = updateMethod; //TODO
        }

        /// <summary>
        /// The types of elements available.
        /// Solid is an element that pauses them game until it is finished being built.
        /// - It may be fused together at a high enough heat :)
        /// Powder is a solid element that does not pause the game as it is being built; it is not one big brick, so to speak.
        /// Liquid is a liquid.
        /// Gas is a gas.
        /// Plasma is a filler state of matter; There will probably only be one element as plasma but still.
        /// None is for other types - invincibles like walls. Will not be part of core; but will be available for modules.
        /// </summary>
        public enum ElementType
        {
            Solid,
            Powder,
            Liquid,
            Gas,
            Plasma,
            None,
        };
    }
}
