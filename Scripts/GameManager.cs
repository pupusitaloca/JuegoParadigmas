using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSDL2.Engine
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
        gameState gameState=gameState.Start;
        private int score;

        MainGame MainGame=new MainGame();

        public MainGame mainGame { get { return MainGame;} }

        static public GameManager Instace
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

        public void Start()
        {
           MainGame.Start();
        }

        public void SetScore(int newScore)
        {
            score = newScore;
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
                    Engine.Draw("assets//Fin.png",0,0);
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
                    if (mainGame.OnDie())
                    {
                        gameState = gameState.End;
                    }

                    break;
            }
        
        }
    }
}
