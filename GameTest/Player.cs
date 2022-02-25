using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NextEngine;

namespace GameTest
{
    public class Player : GameObject
    {
        private float speed = 500;
        private Animation animationDX;
        private Animation animationSX;
        private Animation animation;
        override public float Height { get { return animation.CurrentTexture.Height; } }
        override public float Width { get { return animation.CurrentTexture.Width; } }

        public Player(Vector2 pos) : base("")
        {
            Position = pos;
            IsActive = true;
        }

        public override void LoadContent()
        {
            animationDX = new Animation("CorsaDX", 12, 24);
            animationSX = new Animation("CorsaSX", 12, 24);
            animation = animationDX;
            Rigidbody.CreateBoxFor();
            Rigidbody.Type = RigidBodyType.Player;
            Rigidbody.AddCollisionType(RigidBodyType.Wall);
            DrawManager.Camera.Follow(Position, animation.CurrentTexture);
        }

        public override void Draw()
        {
            animationDX.Update();
            animationSX.Update();
            DrawManager.Layer2.Draw(animation.CurrentTexture, Position, Color.White);
        }

        public override void Update()
        {
            Input();
            DrawManager.Camera.Follow(Position, animation.CurrentTexture);
        }

        public void Input()
        {
            //Horizontal Move
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Rigidbody.Velocity.X = -speed;
                animation = animationSX;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Rigidbody.Velocity.X = speed;
                animation = animationDX;
            }
            else
            {
                Rigidbody.Velocity.X = 0;
            }

            //Vertical Move
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Rigidbody.Velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Rigidbody.Velocity.Y = speed;
            }
            else
            {
                Rigidbody.Velocity.Y = 0;
            }

            //Oblique correction
            if (Rigidbody.Velocity.X != 0 && Rigidbody.Velocity.Y != 0)
            {
                Rigidbody.Velocity.Normalize();
                Rigidbody.Velocity *= speed;
            }

        }

        public override void OnCollide(GameObject other)
        {
            if(other is Wall)
            {
                Debug.WriteLine("panza");
            }
        }
    }
}
