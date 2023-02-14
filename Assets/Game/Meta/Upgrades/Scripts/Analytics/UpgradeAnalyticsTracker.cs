using GameSystem;

namespace Game.Meta
{
    public class UpgradeAnalyticsTracker : IGameReadyElement, IGameFinishElement
    {
        private UpgradesManager upgradesManager;

        [GameInject]
        public void Construct(UpgradesManager upgradesManager)
        {
            this.upgradesManager = upgradesManager;
        }

        void IGameReadyElement.ReadyGame()
        {
            this.upgradesManager.OnLevelUp += this.OnLevelUpUpgrade;
        }

        void IGameFinishElement.FinishGame()
        {
            this.upgradesManager.OnLevelUp -= this.OnLevelUpUpgrade;
        }

        private void OnLevelUpUpgrade(Upgrade upgrade)
        {
            UpgradesAnalytics.LogLevelUpgrade(upgrade);
        }
    }
}