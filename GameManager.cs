using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KpopJumpPRY.Engine.PauseMenu;
using static KpopJumpPRY.Engine.WinMenu;

namespace KpopJumpPRY.Engine
{

    public enum gameState
    {
        Start = 0,
        Game = 1,
        Pause = 2,
        End = 3,
        Win = 4
    }

    public class GameManager
    {
        static GameManager instance;

        private gameState gameState = gameState.Start;
        private gameState previousState = gameState.Start;
        private int score = 0;

        private MainGame mainGame = new MainGame();
        private PauseMenu pauseMenu = new PauseMenu();
        private WinMenu winMenu = new WinMenu();
        private DeathMenu deathMenu = new DeathMenu();

        

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
            Engine.Clear();

            switch (gameState)
            {
                case gameState.Start:
                    Engine.Draw("assets/Menu.png", 0, 0, Engine.ScreenWidth, Engine.ScreenHeight);

                    break;

                case gameState.Game:
                    mainGame.Render();

                    if (mainGame.CurrentScore >= 1000)
                    {
                        gameState = gameState.Win;
                    }

                    break;

                case gameState.Pause:

                    //Console.WriteLine("Render Pause");

                    mainGame.Render();
                    pauseMenu.Render();

                    break;

                case gameState.End:
                    deathMenu.Render();
                    break;

                case gameState.Win:
                    winMenu.Render();
                    break;

            }

            Engine.Show();

        }

        public void Update()

        {
            switch (gameState)
            {
                case gameState.Start:
                    if (Engine.KeyPress(Engine.KEY_X))
                    {
                        gameState = gameState.Game;
                    }
                    break;

                case gameState.Game:

                    if (Engine.KeyPress(Engine.KEY_ESC))
                    {
                        previousState = gameState.Game;
                        gameState = gameState.Pause;
                        break;
                    }

                    mainGame.Update();

                    if (mainGame.CurrentScore >= 1000)
                    {
                        gameState = gameState.Win;
                        break;
                    }

                    if (mainGame.OnDie())
                    {
                        gameState = gameState.End;
                    }

                    break;

                case gameState.End:

                    DeathMenuAction deathAction = deathMenu.Update();

                    switch (deathAction)
                    {
                        case DeathMenuAction.Retry:
                            ReiniciarJuego();
                            gameState = gameState.Game;
                            break;

                        case DeathMenuAction.MainMenu:
                            VolverAlMenu();
                            gameState = gameState.Start;
                            break;
                    }

                    break;
                case gameState.Pause:

                    PauseMenuAction action = pauseMenu.Update();

                    switch (action)
                    {
                        case PauseMenuAction.Resume:
                            gameState = gameState.Game;
                            break;

                        case PauseMenuAction.Restart:
                            ReiniciarJuego();
                            gameState = gameState.Game;
                            break;

                        case PauseMenuAction.MainMenu:
                            VolverAlMenu();
                            gameState = gameState.Start;
                            break;
                    }

                    break;

                case gameState.Win:

                    WinMenuAction winAction = winMenu.Update();

                    //Console.WriteLine($"Score actual: {mainGame.CurrentScore}");

                    switch (winAction)
                    {
                        case WinMenuAction.MainMenu:
                            VolverAlMenu();
                            gameState = gameState.Start;
                            break;
                    }

                    break;
            }

        }
        private void ReiniciarJuego()
        {
            mainGame = new MainGame();
            mainGame.Start();
        }

        private void VolverAlMenu()
        {
            mainGame = new MainGame();
            mainGame.Start();

        }
    }
}