using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine.Scripts;

namespace KpopJumpPRY.Engine
{
    public class MainGame
    {
        Player player;

        Score score;

        public Player Player => player;

        private int limit = 300;

        private int h = 1024;

        public bool Die;

        List<GameObject> gameObjects=new List<GameObject>();

        public List<GameObject> GameObjects => gameObjects;

        List<Platforms> platforms = new List<Platforms>();

        public List<Platforms> Platforms => platforms;

        

        public void Start()
        {
            player = new Player(500, 500);
            platforms.Add(new NormalPlat(500, 600));

            score = new Score(64, 20);

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(150, 420);

                int y = i * 100;

                if (random.Next(0, 2) == 0)
                {
                    platforms.Add(new NormalPlat(x, y));
                }
                else
                {
                    platforms.Add(new MovPlatform(x, y));
                }
            }
        }

        public void Update()
        {
            player.Update();
            score.Update();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }

            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Update();
            }



            if (player.Transform.PosY < limit)
            {
                float offset = limit - player.Transform.PosY;

                player.Transform.Translate(0, offset);

                MoveCamera(offset);
            }


            GeneratePlatforms();
            
            

        }

        public void Render()
        {
            Engine.Clear();
            score.Render();
            player.Render();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Render();
            }

            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Render();
            }
            Engine.Show();
        }

        private void MoveCamera(float offset)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Transform.Translate(0,offset);
            }

            
        }
        public bool OnDie ()
        {
            return player.Transform.PosY > 1024;

            Die = true;


        }
        private void GeneratePlatforms()
        {
            Random random = new Random();

            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].Transform.PosY > 1024)
                {
                    platforms.RemoveAt(i);

                    int x = random.Next(150, 420);

                    int y = -50;

                    if (random.Next(0, 2) == 0)
                    {
                        platforms.Add(new NormalPlat(x, y));
                    }
                    else
                    {
                        platforms.Add(new MovPlatform(x, y));
                    }
                }
            }
        }

    }
}
