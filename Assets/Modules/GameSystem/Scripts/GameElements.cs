using System.Collections;
using System.Collections.Generic;
using GameElements.Zaratust;

namespace GameSystem
{
    public interface IGameElement
    {
    }
    
    //Game lifecycle
    public interface IGameAttachElement : IGameElement
    {
        void AttachGame(IGameContext context);
    }

    public interface IGameDetachElement : IGameElement
    {
        void DetachGame(IGameContext context);
    }

    public interface IGameConstructElement : IGameElement
    {
        void ConstructGame(IGameContext context);
    }

    public interface IGameInitElement : IGameElement
    {
        void InitGame();
    }

    public interface IGameReadyElement : IGameElement
    {
        void ReadyGame();
    }

    public interface IGameStartElement : IGameElement
    {
        void StartGame();
    }

    public interface IGamePauseElement : IGameElement
    {
        void PauseGame();
    }

    public interface IGameResumeElement : IGameElement
    {
        void ResumeGame();
    }

    public interface IGameFinishElement : IGameElement
    {
        void FinishGame();
    }

    public interface IGameElementGroup : IGameElement
    {
        IEnumerable<IGameElement> GetElements();
    }
}