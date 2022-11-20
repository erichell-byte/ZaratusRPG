using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> OnEvent;

        [Button]
        public void Call(int value)
        {
            Debug.Log($"Event {name} was received");
            OnEvent?.Invoke(value);
        }
        
    }
}
