using System;
using Context;
using UnityEngine;

namespace Controllers
{
    public class MouseInput : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        public event Action OnClick;
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                OnClick?.Invoke();
        }
        
        void IStartGameListener.OnStartGame()
        {
            this.enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.enabled = false;
        }
    }
}