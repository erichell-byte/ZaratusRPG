using System.Collections;
using System.Collections.Generic;

namespace GameElements.Zaratust
{
    public interface IGameElement
        {
            
        }
        
        public interface IGameAttachElement : IGameElement
        {
            // Called when this element has registered to a game system

            void AttachGame(IGameContext context);
        }

        public interface IGameDetachElement : IGameElement
        {
            // Called when this element has unregistred from this game

            void DetachGame(IGameContext context);
        }

        public interface IGameInitElement : IGameElement
        {
            //Called when a Game system is initialized
            void InitGame(IGameContext context);
        }

        public interface IGameReadyElement : IGameElement
        {
            //Calls when a Game system is Ready
            void ReadyGame(IGameContext context);
        }

        public interface IGameStartElement : IGameElement
        {
            // Calls when a game system is starte
            void StartGame(IGameContext context);
        }

        public interface IGamePauseElement : IGameElement
        {
            // calls when a game system is pause
            void PauseGame(IGameContext context);
        }
        
        public interface IGameResumeElement : IGameElement
        {
            // calls when a game system is resume
            void ResumeGame(IGameContext context);
        }

        public interface IGameFinishElement : IGameElement
        {
            // calls when a game system is finish
            void FinishGame(IGameContext context);
        }
        
        public interface IGameElementGroup : IGameElement
        {
            // return a collection of element
            IEnumerable<IGameElement> GetElements();
        }
}