using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPartWork
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] 
        private IntEventReceiver _takeDamageReceiver;

        [SerializeField]
        private IntBehaviour _hitPoints;


        private void OnEnable()
        {
            this._takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this._takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }
        
        private void OnDamageTaken(int damage)
        {
            this._hitPoints.Value -= damage;
        }
    }
}
