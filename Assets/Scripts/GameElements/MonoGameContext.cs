using System;
using System.Collections;
using System.Collections.Generic;
using Context;
using GameElements.Tools;
using GameElements.Zaratust;
using UnityEngine;

namespace GameElements
{
    public class MonoGameContext : MonoBehaviour, IGameContext
    {
        public event Action OnLoaded;

        public bool IsAutoRun
        {
            get { return this.autoRun; }
            set { this.autoRun = value; }
        }

        [SerializeField] private bool autoRun = true;

        private bool isLoaded;

        [Space] [SerializeField] private List<MonoBehaviour> gameServices = new();

        [Space] [SerializeField] private List<MonoBehaviour> gameElements = new();

        public event Action OnGameInitialized
        {
            add { this.gameContext.OnGameInitialized += value; }
            remove { this.gameContext.OnGameInitialized -= value; }
        }
        
        public event Action OnGameReady
        {
            add { this.gameContext.OnGameReady += value; }
            remove { this.gameContext.OnGameReady -= value; }
        }
        
        public event Action OnGameStarted
        {
            add { this.gameContext.OnGameStarted += value; }
            remove { this.gameContext.OnGameStarted -= value; }
        }
        public event Action OnGamePaused
        {
            add { this.gameContext.OnGamePaused += value; }
            remove { this.gameContext.OnGamePaused -= value; }
        }
        
        public event Action OnGameResumed
        {
            add { this.gameContext.OnGameResumed += value; }
            remove { this.gameContext.OnGameResumed -= value; }
        }
        
        public event Action OnGameFinished
        {
            add { this.gameContext.OnGameFinished += value; }
            remove { this.gameContext.OnGameFinished -= value; }
        }

        public GameState State
        {
            get { return this.gameContext.State; }
        }

        private readonly IGameContext gameContext;
        
        public MonoGameContext()
        {
            this.gameContext = new GameContext();
        }

        [ContextMenu("Load Game")]
        public void LoadGame()
        {
            if (this.isLoaded)
            {
                Debug.LogWarning("Game is already loading");
                return;
            }
            this.LoadElements();
            this.LoadServices();
            this.isLoaded = true;
            this.OnLoaded?.Invoke();
        }

        [ContextMenu("Init Game")]
        public void InitGame()
        {
            this.gameContext.InitGame();
        }
        [ContextMenu("Ready Game")]
        public void ReadyGame()
        {
            this.gameContext.ReadyGame();
        }
        
        [ContextMenu("Start Game")]
        public void StartGame()
        {
            this.gameContext.StartGame();
        }
        
        [ContextMenu("Start Game")]
        public void PauseGame()
        {
            this.gameContext.PauseGame();
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            this.gameContext.ResumeGame();
        }
        
        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            this.gameContext.FinishGame();
        }

        public void RegisterElement(IGameElement element)
        {
            this.gameContext.RegisterElement(element);
        }
        
        public void UnRegisterElement(IGameElement element)
        {
            this.gameContext.UnRegisterElement(element);
        }
        
        
        public void RegisterService(object element)
        {
            this.gameContext.RegisterService(element);
        }
        
        public void UnRegisterService(object element)
        {
            this.gameContext.UnRegisterService(element);
        }

        public T GetService<T>()
        {
            return this.gameContext.GetService<T>();
        }
        
        public object[] GetAllServices()
        {
            return this.gameContext.GetAllServices();
        }
        
        public object GetService(Type type)
        {
            return this.gameContext.GetService(type);
        }
        
        public bool TryGetService<T>(out T service)
        {
            return this.gameContext.TryGetService(out service);
        }
        
        
        public bool TryGetService(Type type, out object service)
        {
            return this.gameContext.TryGetService(type, out service);
        }

        private IEnumerator Start()
        {
            if (this.autoRun)
            {
                yield return new WaitForEndOfFrame();
                this.LoadGame();
                this.InitGame();
                this.ReadyGame();
                this.StartGame();
            }
        }

        private void LoadElements()
        {
            for (int i = 0, count = this.gameElements.Count; i < count; i++)
            {
                var monoElement = this.gameElements[i];
                if (monoElement is IGameElement gameElement)
                {
                    this.RegisterElement(gameElement);
                }
            }
        }
        
        private void LoadServices()
        {
            for (int i = 0, count = this.gameServices.Count; i < count; i++)
            {
                var monoService = this.gameServices[i];
                if (monoService != null)
                {
                    this.RegisterService(monoService);
                }
            }
        }
#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour gameElement)
        {
            this.gameElements.Add(gameElement);
        }

        public void Editor_AddService(MonoBehaviour gameService)
        {
            this.gameServices.Add(gameService);
        }

        private void OnValidate()
        {
            EditorValidator.ValidateServices(ref this.gameServices);
            EditorValidator.ValidateElements(ref this.gameElements);
        }
#endif
    }
}