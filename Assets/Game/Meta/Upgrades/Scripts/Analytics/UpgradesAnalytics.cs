namespace Game.Meta
{
    public static class UpgradesAnalytics
    {
        public static void LogLevelUpgrade(Upgrade upgrade)
        {
            const string eventName = "hero_upgrade_{0}_level_up";
            var name = string.Format(eventName, upgrade.Id);
        }
    }
}