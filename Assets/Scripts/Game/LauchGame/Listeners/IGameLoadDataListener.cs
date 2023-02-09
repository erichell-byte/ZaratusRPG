using GameManager;

namespace Game.LauchGame.Listeners
{
    public interface IGameLoadDataListener
    {
        void OnLoadData(GameManager.GameManager gameManager);
    }
}