using System;
using Context;
using UnityEngine;

namespace Controllers
{
    public sealed class AxisInput : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        public event Action<Vector3> OnMove;

        public void Awake()
        {
            this.enabled = false;
        }
        
        private void Update()
        {
            HandleInput();
        }

        void IStartGameListener.OnStartGame()
        {
            this.enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.enabled = false;
        }
        
        private void HandleInput()
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (direction != Vector3.zero)
                OnMove?.Invoke(direction);
        }
        
        
    }
}