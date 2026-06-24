using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopJumpPRY.Engine
{
    public class NormalPlat : Platforms
    {
        public NormalPlat() : base(0, 0) { }
        public NormalPlat(int x,int y) : base (x,y)
        {
            sprite = Engine.LoadImage("assets/Platforms/platform.png");
        }

        public override void Render()
        {
            Engine.Draw(sprite, (int)transform.PosX, (int)transform.PosY);
            if (!IsActive) return;

        }

        public override void Update() 
        {
            if (!IsActive) return;
        }
    }
}
