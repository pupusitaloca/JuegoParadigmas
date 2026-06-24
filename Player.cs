namespace KpopJumpPRY.Engine.Scripts
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
            velocityY = 25;
            isJumping = true;

            if (score != null)
            {
                score.addPoint();
            }
            else {
                score = new Score(64, 20);
                score.addPoint();
            }
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
            for (int i = 0; i < GameManager.Instance.MainGame.Platforms.Count; i++)
            {
                Platforms p = GameManager.Instance.MainGame.Platforms[i];

                float playerBottom = transform.PosY + PjHeight;
                float PlatformTop = p.Transform.PosY;

                bool overLapX =
                    transform.PosY + PjWidth > p.Transform.PosX &&
                    transform.PosX < p.Transform.PosX + 70;

                bool TouchingTop =
                    playerBottom >= PlatformTop &&
                    playerBottom <= PlatformTop + 15;


                if (overLapX && TouchingTop && velocityY < 0)
                {
                    if (p is Platforms)
                    {
                        Jump();


                    }


                }
            }
        }
    }
}