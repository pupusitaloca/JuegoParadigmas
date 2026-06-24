using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine;

namespace ProyectoSDL2.Engine
{
    public class Platform_Generator
    {
        List<Platforms> platforms = new List<Platforms>();

        public List<Platforms> Platforms => platforms;

        Random random = new Random();

        int currentY = 800;

        int screenWidth = 640;
        int platWidth = 100;
        int margin = 20;
        public int CurrentY => currentY;
        public Platform_Generator(int num)
        {
            GeneratePlatforms(num);
        }


        public void GeneratePlatforms(int num)
        {

            if (platforms.Count > 0)
            {
                currentY = (int)platforms.Min(p => p.Transform.PosY);
            }
            for (int i = 0; i < num; i++)
            {
                int x = random.Next(margin, screenWidth-platWidth-margin);

                int distance = random.Next(50, 100);

                currentY -= distance;

                int chance = Random.Shared.Next(0, 100);


                if (chance < 70)
                {
                    platforms.Add(new NormalPlat(x, currentY));
                }
                else if (chance < 90)
                {
                    platforms.Add(new MovPlatform(x, currentY));
                }
                else
                {
                    platforms.Add(new FragilePlatforms(x, currentY));
                }


            }
        }
        public void GenerateStartPlatform()
        {
            platforms.Add(
                new NormalPlat(450, 600)
            );
        }

        public void Render()
        {
            for (int i = 0; i < platforms.Count; i++)
            { 
                platforms[i].Render();
            }
        }

        public void Update()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Update();
            }
        }
    } 
}
