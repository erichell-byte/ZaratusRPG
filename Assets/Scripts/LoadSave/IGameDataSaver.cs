using GameElements.Zaratust;

namespace LoadSave
{
    public interface IGameDataSaver
    {
        void SaveData(IGameContext gameContext);
    }
}