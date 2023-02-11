using Game.LauchGame.Listeners;
using Game.LauchGame.SaveGame;

namespace Game.Meta
{
    public sealed class UpgradeMediator : IGameLoadDataListener, IGameSaveDataListener
    {
        
        public void OnLoadData(GameManager.GameManager gameManager)
        {
            throw new System.NotImplementedException();
        }

        public void OnSaveData(GameSaveReason reason)
        {
            throw new System.NotImplementedException();
        }
    }
}