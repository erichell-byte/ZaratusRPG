using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;


namespace MyPartWork
{
    public class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> OnEvent;

        [Button]
        private void Call(int value)
        {
            Debug.Log($"Event {name} was received");
            OnEvent?.Invoke(value);
        }
        
    }
}
