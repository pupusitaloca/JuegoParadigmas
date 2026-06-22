namespace ProyectoSDL2.Engine.Scripts
{
    public class Player : GameObject
    {
        private int ScreenWidth = 640;
        private int ScreenHeight = 1024;

        private int PjWidth = 124;
        private int PjHeight = 120;

        PlayerInput input;
        Score score;


        private float gravity = 0.9f;
        private float velocityY = 0;

        private bool isJumping = false;

        bool isActive = true;

        private Image sprite;

        public Player(int startPosX, int startPosY) : base(startPosX, startPosY)
        {
            input = new PlayerInput(Transform);

            sprite = Engine.LoadImage("assets/PJ/Chuu.png");

            
        }


        public override void Update()
        {
            Gravity();
            Collision();
            input.Update();

        }

        private void Gravity()
        {
            velocityY -= gravity;

            
            transform.Translate(0, -velocityY);
            
        }

        private void Jump()
        {
            velocityY = 20;
            isJumping = true;
        }

        public override void Render()
        {
            if (isActive)
            {
                Engine.Draw(sprite, (int)transform.PosX, (int)transform.PosY);
            }
        }

        public void Collision()
        {
            for (int i = 0; i < GameManager.Instace.mainGame.Platforms.Count; i++)
            {
                Platforms p=GameManager.Instace.mainGame.Platforms[i];

                if (transform.PosX + 100 > p.Transform.PosX &&
                    transform.PosX < p.Transform.PosX + 70 &&
                    transform.PosY + 100 > p.Transform.PosY &&
                    transform.PosY < p.Transform.PosY + 70)
                {
                    if (p is Platforms)
                    {
                        Jump();
                        //score.addPoint();
                    }
                }
            }
        }
    }
}
