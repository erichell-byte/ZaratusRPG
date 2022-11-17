using System;
using System.Collections;
using System.Collections.Generic;
using MyPartWork;
using UnityEngine;


namespace MyPartWork
{


    public class ShotMechanics : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;

        [SerializeField] private IntEventReceiver shotSignal;

        [SerializeField] private Transform shotPoint; 
        
        


        private void OnEnable()
        {
            shotSignal.OnEvent += OnShot;
        }

        private void OnDisable()
        {
            shotSignal.OnEvent -= OnShot;
        }


        private void OnShot(int force)
        {
            var newBullet = Instantiate(bullet, shotPoint.position, Quaternion.identity);

            if (newBullet.TryGetComponent(out Rigidbody bulletRb))
                bulletRb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }
    
    
}
