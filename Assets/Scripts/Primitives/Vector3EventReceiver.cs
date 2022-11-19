using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [Button]
        private void Call(Vector3 value)
        {
            Debug.Log($"Event {name} was received");
            OnEvent?.Invoke(value);
        }
    }
}
