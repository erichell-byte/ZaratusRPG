using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [Button]
        public void Call()
        {
            Debug.Log($"Event was {name} received");
            this.OnEvent?.Invoke();
        }
    }
}
