using Game.LauchGame.SaveGame;

namespace Game.LauchGame.Listeners
{
    public interface IGameSaveDataListener
    {
        void OnSaveData(GameSaveReason reason);
    }
}