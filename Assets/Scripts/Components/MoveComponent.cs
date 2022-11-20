using Primitives;
using UnityEngine;

namespace Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private Vector3EventReceiver moveReceiver;

        public void Move(Vector3 direction)
        {
            this.moveReceiver.Call(direction);
        }
    }
}
