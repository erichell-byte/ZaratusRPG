using System;
using System.Collections;
using System.Collections.Generic;
using MyPartWork;
using UnityEngine;

namespace MyPartWork
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver jumpReceiver;

        [SerializeField] private Rigidbody rb;

        private void OnEnable()
        {
            jumpReceiver.OnEvent += OnJump;
        }
        
        private void OnDisable()
        {
            jumpReceiver.OnEvent -= OnJump;
        }
        
        private void OnJump(int force)
        {
            if (rb.velocity.y == 0)
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}