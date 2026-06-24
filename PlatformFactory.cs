namespace KpopJumpPRY.Engine
{
    public static class PlatformFactory
    {
        public static Platforms CreatePlatform(PlatformType type, int x, int y)
        {
            switch (type)
            {
                case PlatformType.Normal:
                    return new NormalPlat(x, y);

                case PlatformType.Moving:
                    return new MovPlatform(x, y);

                default:
                    return new NormalPlat(x, y);
            }
        }
    }
}