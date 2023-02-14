using GameSystem;

namespace LoadSave
{
    public interface IGameDataSaver
    {
        void SaveData(IGameContext gameContext);
    }
}