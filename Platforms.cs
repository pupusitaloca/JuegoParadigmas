using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine.Scripts;

namespace KpopJumpPRY.Engine
{
    public  abstract class Platforms 
    {
        protected Image sprite;

        protected Transform transform;
        public Transform Transform => transform;

        public Platforms(int startPosX, int startPosY)
          
        {
            transform = new Transform(startPosX, startPosY);
        }

        public abstract void Render();

        public abstract void Update();

    }
}
