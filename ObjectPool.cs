using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine;

namespace ProyectoSDL2.Engine
{
    public class ObjectPool <T> where T : Platforms,new ()
    {
        private Queue<T> available = new Queue<T> ();
        private List<T> active = new List<T> ();

        public List<T> Active=> active;

        public ObjectPool(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                T obj = new T();
                obj.SetActive(false);
                available.Enqueue(obj);
            }


        }

        public T Get(int x, int y)
        {
            T obj;

            if (available.Count > 0)
                obj = available.Dequeue();
            else
                obj = new T();

            obj.Transform.SetPosition(x, y);
            obj.SetActive(true);
            active.Add(obj);
            return obj;
        }

        public void Return(T obj)
        {
            obj.SetActive(false);
            active.Remove(obj);
            available.Enqueue(obj);
        }

        public void ReturnAll()
        {
            foreach (T obj in active)
            {
                obj.SetActive(false);
                available.Enqueue(obj);
            }
            active.Clear();
        }
    }
}
