using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    public class BoxCollider : Collider
    {
        protected float halfWidth;
        protected float halfHeight;

        public float Width { get { return halfWidth * 2f; } }
        public float Height { get { return halfHeight * 2f; } }

        public BoxCollider(Rigidbody owner, int w, int h) : base(owner)
        {
            halfWidth = w * 0.5f;
            halfHeight = h * 0.5f;
        }

        public override bool Collides(Collider collider)
        {
            return collider.Collides(this);
        }

        public override bool Collides(CircleCollider circle)
        {
            float deltaX = circle.Position.X - Math.Max(Position.X - halfWidth,  Math.Min(circle.Position.X, Position.X + halfWidth));
            float deltaY = circle.Position.Y - Math.Max(Position.Y - halfHeight, Math.Min(circle.Position.Y, Position.Y + halfHeight));

            return (deltaX * deltaX + deltaY * deltaY) < (circle.Radius * circle.Radius);
        }

        public override bool Contains(Vector2 point)
        {
            return
                point.X >= Position.X - halfWidth &&
                point.X <= Position.X + halfWidth &&
                point.Y >= Position.Y - halfHeight &&
                point.Y <= Position.Y + halfHeight;
        }

        public override bool Collides(BoxCollider other)
        {
            float deltaX = other.Position.X - Position.X;
            float deltaY = other.Position.Y - Position.Y;

            return
                (Math.Abs(deltaX) <= halfWidth + other.halfWidth) &&
                (Math.Abs(deltaY) <= halfHeight + other.halfHeight);
        }

        public override void Draw(Vector2 pos)
        {
            DrawManager.Layer4.Draw(TextureManager.GetTexure("Square"),
                new Rectangle(
                    new Point((int)pos.X, (int)pos.Y),
                    new Point((int)Width, (int)Height)),
                    Color.Black);
        }
    }
}
