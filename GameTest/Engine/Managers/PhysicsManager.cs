using System.Collections.Generic;

namespace NextEngine
{
    static public class PhysicsManager
    {
        static private List<Rigidbody> CollidableObjects;
        static public bool DebugDraw = true;

        static PhysicsManager()
        {
            CollidableObjects = new List<Rigidbody>();
        }

        public static void Add(Rigidbody obj)
        {
            CollidableObjects.Add(obj);
        }

        static public void Remove(Rigidbody obj)
        {
            CollidableObjects.Remove(obj);
        }

        static public void ClearAll()
        {
            CollidableObjects.Clear();
        }

        public static void Update()
        {
            if (CollidableObjects.Count > 0)
            {
                for (int i = 0; i < CollidableObjects.Count; i++)
                {
                    if (CollidableObjects[i].IsActive)
                    {
                        CollidableObjects[i].Update();
                    }
                }
            }
        }

        public static void Draw()
        {
            if (DebugDraw)
            {
                if (CollidableObjects.Count > 0)
                {
                    for (int i = 0; i < CollidableObjects.Count; i++)
                    {
                        if (CollidableObjects[i].IsActive)
                        {
                            CollidableObjects[i].Draw();
                        }
                    }
                }
            }
        }

        public static void CheckCollisions()
        {
            for (int i = 0; i < CollidableObjects.Count - 1; i++)
            {
                if (CollidableObjects[i].IsActive && CollidableObjects[i].IsCollisionAffected)
                {
                    for (int j = i + 1; j < CollidableObjects.Count; j++)
                    {
                        if (CollidableObjects[j].IsActive && CollidableObjects[j].IsCollisionAffected)
                        {
                            bool firstCheck = CollidableObjects[i].CollisionTypeMatches(CollidableObjects[j].Type);
                            bool secondCheck = CollidableObjects[j].CollisionTypeMatches(CollidableObjects[i].Type);

                            if ((firstCheck || secondCheck) && CollidableObjects[i].Collides(CollidableObjects[j]))
                            {
                                if (firstCheck)
                                {
                                    CollidableObjects[i].GameObject.OnCollide(CollidableObjects[j].GameObject);
                                }

                                if (secondCheck)
                                {
                                    CollidableObjects[j].GameObject.OnCollide(CollidableObjects[i].GameObject);
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
