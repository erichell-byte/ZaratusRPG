using System.Collections;
using System.Collections.Generic;
using GameElements;
using GameElements.Zaratust;
using UnityEngine;

namespace GameManager
{
    public sealed class GameManager
    {
        private readonly List<object> registeredServices;
        private readonly List<object> registeredElements;

        private IGameContext _gameContext;

        private bool gameSetuped;

        public GameManager()
        {
            this.registeredElements = new List<object>();
            this.registeredServices = new List<object>();
        }

        public void Setup(MonoGameContext gameContext)
        {
            for (int i = 0, count = this.registeredServices.Count; i < count; i++)
            {
                var service = this.registeredServices[i];
                gameContext.RegisterService(service);
            }

            for (int i = 0, count = this.registeredElements.Count; i < count; i++)
            {
                var element = this.registeredElements[i];
                if (element is IGameElement gameElement)
                {
                    gameContext.RegisterElement(gameElement);
                }
            }
            gameContext.LoadGame();

            this.gameSetuped = true;
            this._gameContext = gameContext;
        }

        public void InitGame()
        {
            this._gameContext.InitGame();
        }

        public void ReadyGame()
        {
            this._gameContext.ReadyGame();
        }

        public void StartGame()
        {
            this._gameContext.StartGame();
        }

        public T GetSevice<T>()
        {
            return this._gameContext.GetService<T>();
        }

        public bool TryGetService<T>(out T result)
        {
            return this._gameContext.TryGetService(out result);
        }

        public void RegisterService(object service)
        {
            this.registeredServices.Add(service);
            if (this.gameSetuped)
            {
                this._gameContext.RegisterService(service);
            }
        }

        public void UnregisterService(object service)
        {
            this.registeredServices.Remove(service);
            if (gameSetuped)
            {
                this._gameContext.UnRegisterService(service);
            }
        }

        public void RegisterElement(IGameElement element)
        {
            this.registeredElements.Add(element);
            if (this.gameSetuped)
            {
                this._gameContext.RegisterElement(element);
            }
        }

        public void UnregisterElement(IGameElement element)
        {
            this.registeredElements.Remove(element);
            if (this.gameSetuped)
            {
                this._gameContext.UnRegisterElement(element);
            }
        }
    }
}

