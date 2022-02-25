using System;
using System.Collections.Generic;

namespace NextEngine
{
    static public class UpdateManager
    {
        static private List<IUpdatable> UpdatableObjects;

        static UpdateManager()
        {
            UpdatableObjects = new List<IUpdatable>();
        }

        public static void Add(IUpdatable obj)
        {
            UpdatableObjects.Add(obj);
        }

        static public void Remove(IUpdatable obj)
        {
            UpdatableObjects.Remove(obj);
        }

        static public void ClearAll()
        {
            UpdatableObjects.Clear();
        }

        public static void Update()
        {
            if (UpdatableObjects.Count > 0)
            {
                for (int i = 0; i < UpdatableObjects.Count; i++)
                {
                    if (UpdatableObjects[i].IsActive)
                    {
                        UpdatableObjects[i].Update();
                    }
                }
            }
            PhysicsManager.Update();
            PhysicsManager.CheckCollisions();
        }


    }
}
