using KpopJumpPRY.Engine.Scripts;

namespace KpopJumpPRY.Engine
{
    public class Score : GameObject
    {
        Transform trans;
        Image sprite;
        Font arialFont;

        int score = 0;
        public int CurrentScore => score;

        public Score(int x, int y) : base(x, y)
        {
            sprite = Engine.LoadImage("assets/score.png");
            arialFont = Engine.LoadFont("Fonts/arial.ttf", 30);
        }

        public override void Update()
        {
            //addPoint();
        }

        public override void Render()
        {
            Engine.Draw(
             sprite,
             (int)transform.PosX,
             (int)transform.PosY
         );

            Engine.DrawText(
                score.ToString(),
                (int)(transform.PosX + 5),
                (int)(transform.PosY + 0),
                0,
                0,
                0,
                arialFont
            );

        }

        public void addPoint()
        {
            score++;
        }

        public void AddPoints(int points)
        {
            score += points;
        }

    }
}