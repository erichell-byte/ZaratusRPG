using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace MyPartWork
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
