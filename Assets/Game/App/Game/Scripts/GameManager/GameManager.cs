using System.Collections.Generic;
using GameSystem;

namespace Game.App
{
    public sealed class GameManager
    {
        private readonly List<object> registeredService;

        private readonly List<IGameElement> registeredElements;

        private IGameContext gameContext;

        public GameManager()
        {
            this.registeredService = new List<object>();
            this.registeredElements = new List<IGameElement>();
        }

        public void SetupGame(MonoGameContext gameContext)
        {
            for (int i = 0, count = registeredService.Count; i < count; i++)
            {
                var service = this.registeredService[i];
                gameContext.RegisterService(service);
            }

            for (int i = 0, count = registeredElements.Count; i < count; i++)
            {
                var element = this.registeredElements[i];
                gameContext.RegisterElement(element);
            }

            this.gameContext = gameContext;
        }

        public void ConstructGame()
        {
            ((MonoGameContext) gameContext).ConstructGame();
        }

        public void InitGame()
        {
            this.gameContext.InitGame();
        }

        public void ReadyGame()
        {
            this.gameContext.ReadyGame();
        }

        public void StartGame()
        {
            this.gameContext.StartGame();
        }

        public T GetService<T>()
        {
            return this.gameContext.GetService<T>();
        }

        public bool TryGetService<T>(out T result)
        {
            return this.gameContext.TryGetService(out result);
        }

        public void RegisterService(object service)
        {
            this.registeredService.Add(service);
            this.gameContext?.RegisterService(service);
        }

        public void UnregisterService(object service)
        {
            this.registeredService.Remove(service);
            this.gameContext?.UnregisterService(service);
        }

        public void RegisterElement(IGameElement element)
        {
            this.registeredElements.Add(element);
            this.gameContext?.RegisterElement(element);
        }

        public void UnregisterElement(IGameElement element)
        {
            this.registeredElements.Remove(element);
            this.gameContext?.UnregisterElement(element);
        }
        
        
        
    }
}