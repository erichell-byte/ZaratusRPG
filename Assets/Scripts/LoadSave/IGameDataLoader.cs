using GameSystem;

namespace LoadSave
{
    public interface IGameDataLoader
    {
        void LoadData(IGameContext gameContext);
    }
}