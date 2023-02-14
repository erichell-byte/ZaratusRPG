using System;
using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UI.Money;
using UnityEngine;

namespace Game.Meta
{
    public sealed class UpgradesSystemInstaller : MonoGameInstaller
    {
        [SerializeField]
        private UpgradeCatalog catalog;
        
        [Space, ReadOnly, ShowInInspector] 
        private UpgradesManager upgradesManager = new();

        private Upgrade[] upgrades;

        [Space, ReadOnly, ShowInInspector] 
        private UpgradeAnalyticsTracker analyticsTracker = new();

        public override IEnumerable<object> GetServices()
        {
            yield return this.upgradesManager;
        }

        public override IEnumerable<IGameElement> GetElements()
        {
            for (int i = 0, count = this.upgrades.Length; i < count; i++)
            {
                if (this.upgrades[i] is IGameElement element)
                {
                    yield return element;
                }
            }

            yield return this.analyticsTracker;
        }

        private void Awake()
        {
            this.CreateUpgrades();
        }

        private void CreateUpgrades()
        {
            var configs = this.catalog.GetAllUpgrades();
            var count = configs.Length;
            this.upgrades = new Upgrade[count];

            for (var i = 0; i < count; i++)
            {
                var config = configs[i];
                this.upgrades[i] = config.InstantiateUpgrade();
            }
        }

        public override void ConstructGame(IGameContext context)
        {
            this.ConstractUpgrades(context);
            this.ConstructManager(context);
            this.ConstructAnalytics();
            Debug.Log("Construct");
        }

        private void ConstructAnalytics()
        {
            this.analyticsTracker.Construct(upgradesManager);
        }

        private void ConstractUpgrades(IGameContext context)
        {
           GameInjector.InjectAll(context, this.upgrades);
        }

        private void ConstructManager(IGameContext context)
        {
            var moneyStorage = context.GetService<MoneyStorage>();
            this.upgradesManager.Construct(moneyStorage);
            this.upgradesManager.Setup(upgrades);
        }
    }
}