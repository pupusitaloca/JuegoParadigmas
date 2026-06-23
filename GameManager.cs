using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopJumpPRY.Engine
{

    public enum gameState
    {
        Start=0,
        Game=1,
        End=2
       
    }
    public class GameManager
    {
         static GameManager instance;

        private gameState gameState = gameState.Start;
        private int score;

        private MainGame mainGame = new MainGame();

        public MainGame MainGame
        {
            get { return mainGame; }
        }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        private GameManager()
        {
        }

        public void Start()
        {
           MainGame.Start();
        }

        public void SetScore(int newScore)
        {
            //score = newScore;
        }

        public void Render()
        {
            switch (gameState)  
            { 
                case gameState.Start:
                    Engine.Clear();
                    Engine.Draw("assets/Menu.png", 0,0);
                    Engine.Show();
                    break;
                case gameState.Game:
                    mainGame.Render();
                    break;
                case gameState.End:
                    Engine.Clear();
                    Engine.Draw("assets/Fin.png", 0,0);
                    Engine.Show();
                    break;

            
            }


        }

        public void Update() 
        
        {
            switch (gameState) 
            { 
                case gameState.Start:
                    if (Engine.KeyPress(Engine.KEY_X))
                    {
                        gameState=gameState.Game;
                    }
                    break;
                case gameState.Game:
                    mainGame.Update();
                    break;
                case gameState.End:
                    mainGame.Update();

                    if (mainGame.OnDie())
                    {
                        gameState = gameState.End;
                    }
                    break;
            }
        
        }
    }
}
