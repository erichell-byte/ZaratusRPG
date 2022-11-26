using System;
using Context;
using UnityEngine;

namespace Controllers
{
    public class DealthCollision : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        public event Action OnDealth;
        void IStartGameListener.OnStartGame()
        {
            this.enabled = false;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
                OnDealth?.Invoke();
        }
    }
}
