using Game.Meta;

namespace Game.Meta
{
    public static class UpgradeExtensions
    {
        public const string MENU_PATH = "Meta/Upgrades/";

        public static float GetProgress(this Upgrade it)
        {
            return (float)it.Level / it.MaxLevel;
        }

        public static bool IsMaxLevel(this Upgrade it)
        {
            return it.Level >= it.MaxLevel;
        }
    }
}