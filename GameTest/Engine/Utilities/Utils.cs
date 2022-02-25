using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NextEngine
{
    public static class Utils
    {
        static private float _deltaTime;
        static public float DeltaTime { get { return _deltaTime; } }

        static public ContentManager Content;
        static public GraphicsDevice GraphicsDevice;
        static public GraphicsDeviceManager Graphics;

        static public int ScreenHeight { get { return Graphics.PreferredBackBufferHeight; } }
        static public int ScreenWidth { get { return Graphics.PreferredBackBufferWidth; } }

        static public void Init(ContentManager CM, GraphicsDevice GD, GraphicsDeviceManager GDM)
        {
            Content = CM;
            GraphicsDevice = GD;
            Graphics = GDM;
        }

        static public void UpdateDelta(float delta)
        {
            _deltaTime = delta;
        }
    }
}
