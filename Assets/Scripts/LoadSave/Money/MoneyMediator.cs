using System;
using GameElements.Zaratust;
using Services;
using UI.Money;

namespace LoadSave.Money
{
    public class MoneyMediator : IGameDataLoader, IGameDataSaver
    {
        
        [Inject] private MoneyRepository moneyRepository;
        
        void IGameDataLoader.LoadData(IGameContext gameContext)
        {
            if (this.moneyRepository.LoadMoney(out var money))
            {
                var moneyStorage = gameContext.GetService<MoneyStorage>();
                moneyStorage.SetupMoney(money);
            }
        }

        public void SaveData(IGameContext gameContext)
        {
            var moneyStorage = gameContext.GetService<MoneyStorage>();
            moneyRepository.SaveMoney(moneyStorage.Money);
        }
    }
    
}