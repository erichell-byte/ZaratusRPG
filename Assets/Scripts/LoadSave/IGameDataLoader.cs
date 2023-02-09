using GameElements.Zaratust;

namespace LoadSave
{
    public interface IGameDataLoader
    {
        void LoadData(IGameContext gameContext);
    }
}