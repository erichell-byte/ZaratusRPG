using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class MoveMechanics : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver moveReceiver;
        [SerializeField] private Transform moveTransform;

        private void OnEnable()
        {
            this.moveReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            this.moveReceiver.OnEvent -= OnMove;
        }
        
        private void OnMove(Vector3 deltaPosition)
        {
            moveTransform.position += deltaPosition;
        }
    }
}
