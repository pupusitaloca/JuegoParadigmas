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

        private ObjectPool<NormalPlat> normalPool = new ObjectPool<NormalPlat>(20);
        private ObjectPool<MovPlatform> movPool = new ObjectPool<MovPlatform>(10);
        private ObjectPool<FragilePlatforms> fragilePool = new ObjectPool<FragilePlatforms>(5);

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
                    var plat = normalPool.Get(x, currentY);
                    platforms.Add(plat);
                }
                else if (chance < 90)
                {
                    var plat = movPool.Get(x, currentY);
                    platforms.Add(plat);
                }
                else
                {
                    var plat = fragilePool.Get(x, currentY);
                    platforms.Add(plat);
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

        public void RemoveOffscreen(int screenHeight)
        {
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                if (platforms[i].Transform.PosY > screenHeight + 50)
                {
                    
                    if (platforms[i] is NormalPlat n)
                        normalPool.Return(n);
                    else if (platforms[i] is MovPlatform m)
                        movPool.Return(m);
                    else if (platforms[i] is FragilePlatforms f)
                        fragilePool.Return(f);

                    platforms.RemoveAt(i);
                }
            }
        }
    } 
}
