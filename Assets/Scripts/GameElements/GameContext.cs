using System;
using System.Collections.Generic;
using GameElements;
using GameElements.Zaratust;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Context
{/// <summary>
 /// ///// переписать этот скрипт как в проекте
 /// </summary>
    public class GameContext : MonoBehaviour, IGameContext
    {
        public event Action OnGameInitialized;
        public event Action OnGameReady;
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;
        public GameState State { get; protected set; }
        
        [ReadOnly] 
        [ShowInInspector] 
        private readonly List<object> listeners = new();

        [ReadOnly] 
        [ShowInInspector] 
        private readonly List<object> services = new();
        
        public T GetService<T>()
        {
            foreach (var service in services)
            {
                if (service is T result)
                {
                    return result;
                }
            }
            throw new Exception($"Service of type {typeof(T).Name} not found");
        }

        public object[] GetAllServices()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type type)
        {
            throw new NotImplementedException();
        }

        public object[] GetServices(Type type)
        {
            throw new NotImplementedException();
        }

        public bool TryGetService<T>(out T service)
        {
            throw new NotImplementedException();
        }

        public bool TryGetService(Type type, out object service)
        {
            throw new NotImplementedException();
        }

        public void AddService(object service)
        {
            this.services.Add(service);
        }

        public void RemoveService(object service)
        {
            this.services.Remove(service);
        }

        public void RemoveListener(object listener)
        {
            this.listeners.Remove(listener);
        }

        public void AddListener(object listener)
        {
            this.listeners.Add(listener);
        }

        [Button]
        public void ConstructGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IConstructListener constructListener)
                {
                    constructListener.Construct(context: this);
                }
            }
            
            Debug.Log("Game constructed");
        }

        
        public void InitGame()
        {
            throw new NotImplementedException();
        }

        public void ReadyGame()
        {
            throw new NotImplementedException();
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
            Debug.Log("Game started");
        }

        public void PauseGame()
        {
            throw new NotImplementedException();
        }

        public void ResumeGame()
        {
            throw new NotImplementedException();
        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IFinishGameListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
            Debug.Log("Game finish");
        }

        public void RegisterElement(IGameElement element)
        {
            throw new NotImplementedException();
        }


        public void UnRegisterElement(IGameElement element)
        {
            throw new NotImplementedException();
        }

        public void RegisterService(object element)
        {
            throw new NotImplementedException();
        }

        public void UnRegisterService(object element)
        {
            throw new NotImplementedException();
        }
    }
    
}