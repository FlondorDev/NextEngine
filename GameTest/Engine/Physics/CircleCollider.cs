using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    public class CircleCollider:Collider
    {
        public float Radius;

        public CircleCollider(Rigidbody owner, float radius) : base(owner)
        {
            Radius = radius;
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.Position - Position;
            return (dist.LengthSquared() <= Math.Pow(other.Radius + Radius, 2));
        }

        public override bool Collides(BoxCollider other)
        {
            return other.Collides(this);
        }

        public override bool Contains(Vector2 point)
        {
            Vector2 distaFromCenter = point - Position;
            return distaFromCenter.LengthSquared() <= (Radius * Radius);
        }

        public override void Draw(Vector2 pos)
        {
            DrawManager.Layer4.Draw(TextureManager.GetTexure("Ball"),
                new Rectangle(
                    new Point((int) pos.X, (int)pos.Y),
                    new Point((int)Radius * 2, (int)Radius * 2)),
                    Color.Black);
        }
    }
}
