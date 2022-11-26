using System;
using Context;
using UnityEngine;

namespace Controllers
{
    public class JumpInput : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        public event Action OnJump;
        void IStartGameListener.OnStartGame()
        {
            this.enabled = true;
        }
        
        void IFinishGameListener.OnFinishGame()
        {
            this.enabled = false;
        }
        
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
        }
    }
}
