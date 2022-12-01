using System;
using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class Component_TriggerEvents : MonoBehaviour, IComponent_TriggerEvents
    {
        [SerializeField] private EventBehaviour_Trigger eventReceiver;
        
        public event Action<Collider> OnEntered
        {
            add { this.eventReceiver.OnTriggerEntered += value; }
            remove { this.eventReceiver.OnTriggerEntered -= value; }
        }
        
        public event Action<Collider> OnStaying
        {
            add { this.eventReceiver.OnTriggerStaying += value; }
            remove { this.eventReceiver.OnTriggerStaying -= value; }
        }
        
        public event Action<Collider> OnExit
        {
            add { this.eventReceiver.OnTriggerExited += value; }
            remove { this.eventReceiver.OnTriggerExited -= value; }
        }
    }
}