
using System;
using UnityEngine;

namespace Primitives
{
    public class EventBehaviour_Trigger : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;
        public event Action<Collider> OnTriggerStaying;
        public event Action<Collider> OnTriggerExited;

        private void OnTriggerEnter(Collider other)
        {
            this.OnTriggerEntered?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            this.OnTriggerStaying?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.OnTriggerExited?.Invoke(other);
        }
    }
}