using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MyPartWork
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
