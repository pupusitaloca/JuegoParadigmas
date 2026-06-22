using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoSDL2.Engine.Scripts;

namespace ProyectoSDL2.Engine
{
    public class Score:GameObject
    {
        Transform trans;
        Image sprite;
        int score = 0;
        Font arialFont;

        public Score(int x,int y) : base(x,y)
        {
            sprite = Engine.LoadImage("assets/score.png");
            arialFont = Engine.LoadFont("Fonts/arial.ttf", 30);
        }

        public override void Update()
        {
            addPoint();
        }

        public override void Render()
        {
            Engine.Draw(
             sprite,
             (int)transform.PosX,
             (int)transform.PosY
         );

            Engine.DrawText(
                score.ToString(),
                (int)(transform.PosX + 50),
                (int)(transform.PosY + 10),
                0,
                0,
                0,
                arialFont
            );

        }

        public void addPoint()
        {
            score++;
        }
    }
}
