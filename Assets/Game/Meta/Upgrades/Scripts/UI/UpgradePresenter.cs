
using UI.Money;

namespace Game.Meta
{
    // TODO Не реализована локализация, сделаны заглушки
    public sealed class UpgradePresenter
    {
        private readonly Upgrade upgrade;

        private readonly UpgradeView view;

        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        public UpgradePresenter(Upgrade upgrade, UpgradeView view)
        {
            this.upgrade = upgrade;
            this.view = view;
        }

        public void Construct(UpgradesManager upgradesManager, MoneyStorage moneyStorage)
        {
            this.upgradesManager = upgradesManager;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.view.SetIcon(upgrade.Metadata.icon);
            this.view.UpgradeButton.AddListener(OnButtonClicked);

            this.upgrade.OnLevelUp += this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged += OnMoneyChanged;
            
            this.UpdateTitle();
            this.UpdateLevel();
            this.UpdateStats();
            this.UpdateButtonPrice();
            this.UpdateButtonState();
        }

        public void Stop()
        { 
            this.view.UpgradeButton.RemoveListener(OnButtonClicked);
            this.upgrade.OnLevelUp -= this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged -= OnMoneyChanged;

        }
        
        #region UIEvents

        private void OnButtonClicked()
        {
            if (this.upgradesManager.CanLevelUp(this.upgrade))
            {
                this.upgradesManager.LevelUp(this.upgrade);
            }
        }

        #endregion

        #region ModelEvents

        private void OnLevelUp(int level)
        {
            this.UpdateLevel();
            this.UpdateStats();
            this.UpdateButtonPrice();
        }

        private void OnMoneyChanged(int newValue)
        {
            this.UpdateButtonState();
        }
        
        #endregion

        private void UpdateTitle()
        {
            var title = this.upgrade.Metadata.localizedTitle;
            this.view.SetTitle(title);
        }
        
        private void UpdateLevel()
        {
            var title = "Common|LEVEL";
            this.view.SetLevel(title, this.upgrade.Level, this.upgrade.MaxLevel);
        }
        
        private void UpdateStats()
        {
            var title = "Common|VALUE";
            if (this.upgrade.IsMaxLevel())
            {
                this.view.SetValue(title, this.upgrade.CurrentStats,null);
            }
            else
            {
                this.view.SetValue(title, this.upgrade.CurrentStats, this.upgrade.NextImprovement);    
            }
        }
        
        private void UpdateButtonPrice()
        {
            var priceText = this.upgrade.NextPrice.ToString();
            this.view.UpgradeButton.SetPrice(priceText);
        }
        
        private void UpdateButtonState()
        {
            var upgradeButton = this.view.UpgradeButton;
            if (this.upgrade.IsMaxLevel())
            {
                upgradeButton.SetState(UpgradeButton.State.MAX);
                return;
            }

            var state = this.upgrade.NextPrice <= this.moneyStorage.Money
                ? UpgradeButton.State.AVAILABLE
                : UpgradeButton.State.LOCKED;
            
            upgradeButton.SetState(state);
        }

        

        

        

    }
}