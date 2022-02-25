using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NextEngine;

namespace GameTest
{
    public class Wall : GameObject
    {
        
        public Wall(Vector2 pos) : base("Ball")
        {
            base.Position = pos;
            IsActive = true;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            Rigidbody.CreateBoxFor();
            Rigidbody.Type = RigidBodyType.Wall;
            Rigidbody.AddCollisionType(RigidBodyType.Player);
        }

        public override void Draw()
        {
            
            DrawManager.Layer1.Draw(base.Texture, base.Position, Color.White);
        }

        public override void Update()
        {
            
        }

        public override void OnCollide(GameObject other)
        {
            if (other is Player)
            {
                Debug.WriteLine("Bazunga");
            }
        }
    }
}
