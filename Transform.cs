using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopJumpPRY.Engine.Scripts
{
    public class Transform
    {
        //posiciones
       float posX, posY;

        public float PosX => posX;
        public float PosY => posY;

        //constructor
        public Transform(float x, float y)
        {
            posX = x;
            posY = y;
        }

        //translate
        public void Translate(float moveX, float moveY)
        {
            posX += moveX;
            posY += moveY;
        }

        public void SetPosition(int x, int y)
        {

            posX = x;
            posY = y;
        }


    }
}
