using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Context
{
    public class GameContext : MonoBehaviour
    {
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
    }
    
}