using System;

namespace GameElements.Zaratust
{

    public interface IGameContext
    {
        event Action OnGameInitialized;

        event Action OnGameReady;

        event Action OnGameStarted;

        event Action OnGamePaused;

        event Action OnGameResumed;

        event Action OnGameFinished;

        GameState State { get; }
        
        //Lifecycle

        void InitGame();

        void ReadyGame();

        void StartGame();

        void PauseGame();

        void ResumeGame();

        void FinishGame();
        
        //Elements

        void RegisterElement(IGameElement element);

        void UnRegisterElement(IGameElement element);
        
        //Services

        void RegisterService(IGameElement element);

        void UnRegisterService(IGameElement element);

        T GetService<T>();

        object[] GetAllServices();

        object GetService(Type type);

        bool TryGetService<T>(out T service);
        
        bool TryGetService(Type type, out object service);
    }

}