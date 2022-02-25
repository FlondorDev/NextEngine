using System;
using System.Collections.Generic;

namespace NextEngine
{
    static public class LoaderManager
    {
        static private List<ILoadable> LoadableObjects;

        static LoaderManager()
        {
            LoadableObjects = new List<ILoadable>();
        }

        public static void Add(ILoadable obj)
        {
            LoadableObjects.Add(obj);
        }

        static public void Remove(ILoadable obj)
        {
            LoadableObjects.Remove(obj);
        }

        static public void ClearAll()
        {
            LoadableObjects.Clear();
        }

        public static void LoadContent()
        {
            TextureManager.LoadContent();

            if(LoadableObjects.Count > 0)
            {
                for (int i = 0; i < LoadableObjects.Count; i++)
                {
                    LoadableObjects[i].LoadContent();
                }
            }
        }
    }
}
