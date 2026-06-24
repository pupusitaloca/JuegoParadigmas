namespace KpopJumpPRY.Engine
{
    public enum DeathMenuAction
    {
        None,
        Retry,
        MainMenu
    }

    public class DeathMenu
    {
        private Font font = Engine.LoadFont("assets/arial.ttf", 24);

        private const int retryX = 180;
        private const int retryY = 360;
        private const int mainMenuX = 180;
        private const int mainMenuY = 430;
        private const int buttonWidth = 280;
        private const int buttonHeight = 55;

        public DeathMenuAction Update()
        {
            if (Engine.MouseClick(Engine.MOUSE_LEFT, out int mouseX, out int mouseY))
            {
                if (IsInside(mouseX, mouseY, retryX, retryY, buttonWidth, buttonHeight))
                {
                    return DeathMenuAction.Retry;
                }

                if (IsInside(mouseX, mouseY, mainMenuX, mainMenuY, buttonWidth, buttonHeight))
                {
                    return DeathMenuAction.MainMenu;
                }
            }

            return DeathMenuAction.None;
        }

        public void Render()
        {
            Engine.DrawFilledRect(0, 0, Engine.ScreenWidth, Engine.ScreenHeight, 135, 206, 235, 255);

            Engine.DrawText("¡¡¡Felicidades, has muerto!!!", 155, 300, 0, 0, 0, font);

            DrawButton(retryX, retryY, buttonWidth, buttonHeight, "REINTENTAR");
            DrawButton(mainMenuX, mainMenuY, buttonWidth, buttonHeight, "VOLVER AL MENU");
        }

        private void DrawButton(int x, int y, int width, int height, string text)
        {
            Engine.DrawFilledRect(x, y, width, height, 180, 180, 180);
            Engine.DrawRect(x, y, width, height, 0, 0, 0);

            int textX = x + 25;

            if (text == "REINTENTAR")
            {
                textX = x + 65;
            }

            Engine.DrawText(text, textX, y + 15, 0, 0, 0, font);
        }

        private bool IsInside(int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return mouseX >= x && mouseX <= x + width && mouseY >= y && mouseY <= y + height;
        }
    }
}