using System;
using Primitives;
using UnityEngine;

namespace Components
{
    public class DealthComponent : MonoBehaviour, IDealthComponent
    {
        [SerializeField] private EventReceiver deathReceiver;
        
        public event Action OnDeath
        {
            add { this.deathReceiver.OnEvent += value; }
            remove { this. deathReceiver.OnEvent -= value;} 
        }

        public void Dealth()
        {
            deathReceiver.Call();
        }
    }
}