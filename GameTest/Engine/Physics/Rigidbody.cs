using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    public enum RigidBodyType { Player = 1, Wall = 2, c = 4, d = 8, e = 16 }

    public class Rigidbody
    {
        public RigidBodyType Type;

        protected uint collisionMask;

        public Vector2 Velocity;

        public GameObject GameObject;

        public bool IsActive { get { return GameObject.IsActive; } }

        public bool IsCollisionAffected = true;

        public Collider Collider;

        public Vector2 Position { get { return new Vector2(GameObject.Position.X + (GameObject.Width *0.5f), GameObject.Position.Y + (GameObject.Height * 0.5f)) ; } }

        public Rigidbody(GameObject owner)
        {
            GameObject = owner;
            PhysicsManager.Add(this);
        }

        public void Update()
        {
            GameObject.Position += Velocity * Utils.DeltaTime;
        }

        public bool Collides(Rigidbody other)
        {      
            return Collider.Collides(other.Collider);
        }

        public void AddCollisionType(RigidBodyType type)
        {
            collisionMask |= (uint)type;
        }

        public void AddCollisionType(uint type)
        {
            collisionMask |= type;
        }

        public bool CollisionTypeMatches(RigidBodyType type)
        {
            return ((uint)type & collisionMask) != 0;
        }

        public void Draw()
        {
            Collider.Draw(GameObject.Position);
        }

        public void CreateCircleFor(float rad = 0, bool innerCircle = true)
        {
            float radius;

            if (rad == 0)
            {
                if (innerCircle)
                {
                    if (GameObject.HalfWidth < GameObject.HalfHeight)
                    {
                        radius = GameObject.HalfWidth;
                    }
                    else
                    {
                        radius = GameObject.HalfHeight;
                    }
                }
                else
                {
                    radius = (float)Math.Sqrt(GameObject.HalfWidth * GameObject.HalfWidth + GameObject.HalfHeight * GameObject.HalfHeight);
                }

                Collider = new CircleCollider(this, radius);
            }
            else
            {
                Collider = new CircleCollider(this, rad);
            }
        }

        public void CreateBoxFor(int w = 0, int h = 0)
        {
            if (h == 0 || w == 0)
            {
                Collider = new BoxCollider(this, (int)GameObject.Width, (int)GameObject.Height);
            }
            else
            {
                Collider = new BoxCollider(this, w, h);
            }

        }
    }
}
