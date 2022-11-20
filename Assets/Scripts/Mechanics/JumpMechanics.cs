using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver jumpReceiver;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform groundChecker;
        [SerializeField] private LayerMask notPlayerLayer;

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
            if (Physics.Raycast(groundChecker.transform.position, Vector3.down,0.3f, notPlayerLayer))
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
               
            }
        }
    }
}