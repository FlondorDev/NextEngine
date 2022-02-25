using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    abstract public class Collider
    {
        public Rigidbody Rigidbody;
        public Vector2 Offset;
        public Vector2 Position { get { return Rigidbody.Position + Offset; } }
             
        public Collider(Rigidbody owner)
        {
            Rigidbody = owner;
            Offset = Vector2.Zero;
        }

        public abstract bool Collides(Collider collider);

        public abstract bool Contains(Vector2 point);

        public abstract bool Collides(CircleCollider collider);

        public abstract bool Collides(BoxCollider collider);

        virtual public void Draw(Vector2 pos)
        {

        }
    }
}
