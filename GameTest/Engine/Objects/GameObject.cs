using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    public class GameObject : IDrawable, IUpdatable, ILoadable
    {
        public Vector2 Position;
        public Texture2D Texture;
        protected string textureKey;
        protected Rigidbody Rigidbody;
        public bool IsActive { get; set; } = false;
        virtual public float Height { get { return Texture.Height; } }
        virtual public float Width{ get { return Texture.Width; } }
        public float HalfHeight { get { return Height * 0.5f; } }
        public float HalfWidth { get { return Width * 0.5f; } }

        public GameObject(string textureKey)
        {
            DrawManager.Add(this);
            UpdateManager.Add(this);
            LoaderManager.Add(this);
            Rigidbody = new Rigidbody(this);
            this.textureKey = textureKey;
            
        }

        virtual public void LoadContent()
        {
            Texture = TextureManager.GetTexure(textureKey);
        }

        virtual public void Update()
        {

        }

        public virtual void OnCollide(GameObject other)
        {

        }

        virtual public void Draw()
        {
            DrawManager.Layer2.Draw(Texture, Position, Color.White);
        }
    }
}
