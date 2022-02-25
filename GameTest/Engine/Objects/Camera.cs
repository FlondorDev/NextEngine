using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NextEngine
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Vector2 targetPosition, Texture2D targetTexture )
        {
            var position = Matrix.CreateTranslation(
                -targetPosition.X - (targetTexture.Width / 2),
                -targetPosition.Y - (targetTexture.Height / 2),
                0);

            var offset = Matrix.CreateTranslation(
                Utils.ScreenWidth / 2,
                Utils.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}

