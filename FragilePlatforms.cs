using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine;
using KpopJumpPRY.Engine.Scripts;
using ProyectoSDL2.Engine;

namespace KpopJumpPRY.Engine
{
    public class FragilePlatforms:Platforms,Ibreakable
    {

        private bool breaking = false;
        private int timer = 0;
        private float fallSpeed = 0;
        private Animator breakAnim;
        private Animator CurrentState;
        public FragilePlatforms(int x, int y) : base(x, y)
        {
            sprite = new Image("assets/Platforms/Broken.png");
            CreateAnimation();
            CurrentState = breakAnim;
        }

        public override void Render()
        {
            if (breaking)
            {
                Engine.Draw(
                    CurrentState.CurrentFrame,
                    (int)transform.PosX,
                    (int)transform.PosY
                );
            }
            else
            {
                Engine.Draw(
                    sprite,
                    (int)transform.PosX,
                    (int)transform.PosY
                );
            }
        }

        public override void Update()
        {
            if (breaking)
            {
                CurrentState.Update();

                fallSpeed += 0.4f;
                transform.Translate(0, fallSpeed);
            }
        }
        private void CreateAnimation()
        {
            List<Image> breakTextures = new List<Image>();
            for (int i = 2; i < 4; i++)
            {
                Image frame = Engine.LoadImage($"assets/Platforms/Broken ({i}).png");
                breakTextures.Add(frame);
            }
            breakAnim= new Animator("breakAnim",breakTextures,0.01f,false);
        }

        public void BreakPlat() 
        {
            breaking = true;

        }


    }
}
