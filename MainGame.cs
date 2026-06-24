using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine.Scripts;
using ProyectoSDL2.Engine;

namespace KpopJumpPRY.Engine
{
    public class MainGame
    {
        Player player;

        Score score;

        Platform_Generator platform;

        public Platform_Generator Platform => platform;

        public int CurrentScore => score != null ? score.CurrentScore : 0;
        public Player Player => player;

        int nextPlatformY;

        private int limit = 300;
        private int screenHeight = 800;
        private int minPlatformCount = 20;

        

        public bool Die;

        List<GameObject> gameObjects=new List<GameObject>();

        public List<GameObject> GameObjects => gameObjects;

        public void Start()
        {
            player = new Player(500, 450);

            platform = new Platform_Generator(0);  
            platform.GenerateStartPlatform();
            platform.GeneratePlatforms(30);

            score = new Score(20, 20);


        }

        public void Update()
        {
            player.Update();
            platform.Update();

            if (score != null)
            {
                score.Update();
            }
            else
            {
                score = new Score(64, 20);
                score.Update();
            }
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }

            if (player.Transform.PosY < limit)
            {
                float offset = limit - player.Transform.PosY;

                player.Transform.Translate(0, offset);

                MoveCamera(offset);
            }

            platform.RemoveOffscreen(screenHeight);


            if (platform.Platforms.Count < minPlatformCount)
            {
                platform.GeneratePlatforms(10);
            }


        }

        public void Render()
        {
            Engine.Clear();
            player.Render();
            platform.Render();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Render();
            }
            if (score != null)
            {
                score.Render();
            }
            else
            {
                score = new Score(64, 20);
                score.Render();
            }

            Engine.Show();
        }

        private void MoveCamera(float offset)
        {

            

            for (int i = 0; i < platform.Platforms.Count; i++)
            {
                platform.Platforms[i].Transform.Translate(0,offset);
            }

            

        }
        public bool OnDie ()
        {
            if (player.Transform.PosY > screenHeight)
            {
                Die = true;
                return true;
            }
            return false;
        }
        

    }
}
