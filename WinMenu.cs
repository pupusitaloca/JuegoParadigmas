namespace KpopJumpPRY.Engine
{
    public class WinMenu
    {
        public enum WinMenuAction
        {
            None,
            MainMenu
        }

        private Font font = Engine.LoadFont("assets/arial.ttf", 24);

        private const int buttonX = 220;
        private const int buttonY = 420;
        private const int buttonWidth = 200;
        private const int buttonHeight = 50;

        public void Render()
        {
            Engine.DrawFilledRect(0, 0, Engine.ScreenWidth, Engine.ScreenHeight, 255, 255, 255, 255);

            Engine.DrawText("¡¡¡Felicidades, ganaste!!!", 160, 300, 0, 0, 0, font);

            DrawButton(buttonX, buttonY, buttonWidth, buttonHeight, "MENU");
        }

        private void DrawButton(int x, int y, int w, int h, string text)
        {
            Engine.DrawFilledRect(x, y, w, h, 180, 180, 180);
            Engine.DrawRect(x, y, w, h, 0, 0, 0);
            Engine.DrawText(text, x + 60, y + 15, 0, 0, 0, font);
        }

        public WinMenuAction Update()
        {
            if (Engine.MouseClick(Engine.MOUSE_LEFT, out int mouseX, out int mouseY))
            {
                if (IsInside(mouseX, mouseY, buttonX, buttonY, buttonWidth, buttonHeight))
                {
                    return WinMenuAction.MainMenu;
                }
            }

            return WinMenuAction.None;
        }

        private bool IsInside(int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return mouseX >= x && mouseX <= x + width && mouseY >= y && mouseY <= y + height;
        }
    }
}