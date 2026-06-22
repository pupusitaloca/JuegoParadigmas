using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoSDL2.Engine.Scripts;

namespace ProyectoSDL2.Engine
{
    public abstract class GameObject
    {
        protected Transform transform;
        public Transform Transform => transform;

        public GameObject(int startPosX, int startPosY)
        {
            transform = new Transform(startPosX, startPosY);
        }

        public abstract void Render();

        public abstract void Update();


    }
}
