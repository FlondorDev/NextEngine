using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    static public class TextureManager
    {

        static public Dictionary<string, Texture2D> TextureList;

        static TextureManager()
        {
            TextureList = new Dictionary<string, Texture2D>();
        }

        static public void LoadContent()
        {
            AddTexture("Ball", "ball");
            AddTexture("Square", "square");

            for (int i = 0; i < 12; i++)
            {
                AddTexture($"CorsaDX{i}", $"Corsa/DX/CORSA-{i}");
                AddTexture($"CorsaSX{i}", $"Corsa/SX/CORSA-{i}");
            }

        }

        static public void AddTexture(string key, string texturePath)
        {
            TextureList.Add(key,Utils.Content.Load<Texture2D>(texturePath));
        }

        static public Texture2D GetTexure(string key)
        {
            return TextureList[key];
        }

        static public void RemoveTexture(string key)
        {
            TextureList.Remove(key);
        }

        static public void ClearAll()
        {
            TextureList.Clear();
        }
    }
}
