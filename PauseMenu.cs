namespace KpopJumpPRY.Engine
{
    public class PauseMenu
    {
        public enum PauseMenuAction
        {
            None,
            Resume,
            Restart,
            MainMenu
        }

        private Font font = Engine.LoadFont("assets/arial.ttf", 24);

        private const int buttonX = 220;
        private const int buttonWidth = 200;
        private const int buttonHeight = 50;

        private const int resumeY = 320;
        private const int restartY = 400;
        private const int menuY = 480;

        public void Render()
        {
            Engine.DrawFilledRect(0, 0, 640, 1024, 255, 255, 255, 120);
             
            Engine.DrawFilledRect(170, 250, 300, 350, 230, 230, 230, 255);

            Engine.DrawRect(170, 250, 300, 350, 0, 0, 0);

            DrawButtons();
        }

        private void DrawButtons()
        {
            DrawButton( 220, 320, 200, 50, "REANUDAR");

            DrawButton( 220, 400, 200, 50, "REINICIAR");

            DrawButton( 220, 480, 200, 50, "MENU");
        }

        private void DrawButton( int x, int y, int w, int h, string text)
        {
            Engine.DrawFilledRect( x, y, w, h, 180, 180, 180);

            Engine.DrawRect( x, y, w, h, 0, 0, 0);

            Engine.DrawText( text, x + 20, y + 15, 0, 0, 0, font);
        }

        public PauseMenuAction Update()
        {
            if (Engine.MouseClick(
                Engine.MOUSE_LEFT,
                out int mouseX,
                out int mouseY))
            {
                if (IsInside(mouseX, mouseY,
                             buttonX, resumeY,
                             buttonWidth, buttonHeight))
                {
                    return PauseMenuAction.Resume;
                }

                if (IsInside(mouseX, mouseY,
                             buttonX, restartY,
                             buttonWidth, buttonHeight))
                {
                    return PauseMenuAction.Restart;
                }

                if (IsInside(mouseX, mouseY,
                             buttonX, menuY,
                             buttonWidth, buttonHeight))
                {
                    return PauseMenuAction.MainMenu;
                }
            }

            return PauseMenuAction.None;
        }

        private bool IsInside( int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return mouseX >= x && mouseX <= x + width && mouseY >= y && mouseY <= y + height;
        }
    }
}