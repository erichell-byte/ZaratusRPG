using System.Collections.Generic;
using GameElements.Zaratust;
using GameSystem;
using Meta.Upgrades;
using Sirenix.OdinInspector;
using UI.Money;
using UnityEngine;

namespace Game.Meta
{
    [AddComponentMenu(UpgradeExtensions.MENU_PATH + "Upgrade List Presenter")]
    
    public class UpgradeListPresenter : MonoBehaviour, IGameConstructElement
    {
        [SerializeField] private UpgradeView viewPrefab;

        [SerializeField] private Transform viewsContainer;

        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        private readonly List<UpgradePresenter> presenters;

        private readonly List<UpgradeView> views;

        public UpgradeListPresenter()
        {
            presenters = new List<UpgradePresenter>();
            views = new List<UpgradeView>();
        }

        [Button]
        public void Show()
        {
            CreateUpgrades();
            ShowUpgrades();
        }
        
        [Button]
        public void Hide()
        {
            DestroyUpgrades();
        }
        
        private void CreateUpgrades()
        {
            var upgrades = this.upgradesManager.GetAllUpgrades();
            for (int i = 0, count = upgrades.Length;i < count; i++)
            {
                var view = Instantiate(this.viewPrefab, this.viewsContainer);
                this.views.Add(view);

                var model = upgrades[i];
                var presenter = new UpgradePresenter(model, view);
                presenter.Construct(upgradesManager, moneyStorage);
                this.presenters.Add(presenter);
            }
            
        }
        
        private void ShowUpgrades()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        private void DestroyUpgrades()
        {
            var count = this.presenters.Count;
            for (var i = 0; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();

                var view = this.views[i];
                Destroy(view.gameObject);
            }
            this.presenters.Clear();
            this.views.Clear();
        }


        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.upgradesManager = context.GetService<UpgradesManager>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}