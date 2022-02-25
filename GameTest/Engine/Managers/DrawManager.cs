using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    static public class DrawManager
    {
        static private List<IDrawable> DrawableObjects;

        static public SpriteBatch Layer0;
        static public SpriteBatch Layer1;
        static public SpriteBatch Layer2;
        static public SpriteBatch Layer3;
        static public SpriteBatch Layer4;
        static public Camera Camera;


        static DrawManager()
        {
            DrawableObjects = new List<IDrawable>();
            Layer0 = new SpriteBatch(Utils.GraphicsDevice);
            Layer1 = new SpriteBatch(Utils.GraphicsDevice);
            Layer2 = new SpriteBatch(Utils.GraphicsDevice);
            Layer3 = new SpriteBatch(Utils.GraphicsDevice);
            Layer4 = new SpriteBatch(Utils.GraphicsDevice);
            Camera = new Camera();
        }

        public static void Add(IDrawable obj)
        {
            DrawableObjects.Add(obj);
        }

        static public void Remove(IDrawable obj)
        {
            DrawableObjects.Remove(obj);
        }

        static public void ClearAll()
        {
            DrawableObjects.Clear();
        }

        public static void Draw()
        {
            if(DrawableObjects.Count > 0)
            {
                Layer0.Begin(transformMatrix: Camera.Transform);
                Layer1.Begin(transformMatrix: Camera.Transform);
                Layer2.Begin(transformMatrix: Camera.Transform);
                Layer3.Begin(transformMatrix: Camera.Transform);
                Layer4.Begin(transformMatrix: Camera.Transform);

                for (int i = 0; i < DrawableObjects.Count; i++)
                {
                    if (DrawableObjects[i].IsActive)
                    {
                        PhysicsManager.Draw();
                        DrawableObjects[i].Draw();
                    }
                }

                Layer0.End();
                Layer1.End();
                Layer2.End();
                Layer3.End();
                Layer4.End();
            }
        }
    }
}
