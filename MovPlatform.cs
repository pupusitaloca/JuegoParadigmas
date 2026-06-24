using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopJumpPRY.Engine
{
    public class MovPlatform : Platforms
    {
        private int speed = 3;

        private bool goingRight = true;
        public MovPlatform() : base(0, 0) { }
        public MovPlatform(int x, int y) : base(x, y)
        {
            sprite = Engine.LoadImage("assets/Platforms/platform.png");
        }

        public override void Render()
        {
            Engine.LoadImage(sprite, (int)transform.PosX, (int)transform.PosY);
            if (!IsActive) return;
        }

        public override void Update()
        {
            if (!IsActive) return;
            MoveRight();
            if (goingRight)
            {
                transform.Translate(speed, 0);
            }
            else 
            {
                transform.Translate(-speed, 0);
            }


        }

        private void MoveRight()
        {
            if (transform.PosX < 0)
            {
                goingRight = true;
            }

            if(transform.PosX > 500)
            {
                goingRight=false;
            }
        }

       
    }
}
