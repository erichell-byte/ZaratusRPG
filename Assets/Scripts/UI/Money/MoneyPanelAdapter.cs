
using Sirenix.OdinInspector;
using UnityEngine;
using GameSystem;

namespace UI.Money
{
    public class MoneyPanelAdapter : MonoBehaviour//, IGameInitElement, IGameReadyElement, IGameFinishElement
    {

        [SerializeField] private MoneyPanel panel;

        private MoneyStorage storage;

        //TODO найти в проекте интерфейсы для отслеживания 
        // void IGameInitElement.InitGame(IGameContext context)
        // {
        //     this.storage = context.GetService<MoneyStorage>();
        //     var money = storage.Money;
        //     this.panel.SetupMoney(money);
        // }
        //
        // void IGameReadyElement.ReadyGame(IGameContext context)
        // {
        //     this.storage.OnMoneySpent += this.OnMoneySpent;
        // }
        //
        // void IGameFinishElement.FinishGame(IGameContext context)
        // {
        //     this.storage.OnMoneySpent -= this.OnMoneySpent;
        // }
        
        private void OnMoneySpent(int amount)
        {
            panel.DecrementMoney(amount);
        }
#if UNITY_EDITOR

        [Button]
        private void Editor_UpdateMoney()
        {
            this.panel.SetupMoney(this.storage.Money);
        }
#endif
        
    }
}