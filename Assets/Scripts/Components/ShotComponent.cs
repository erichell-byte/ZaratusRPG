using Primitives;
using UnityEngine;

namespace Components
{
    public class ShotComponent : MonoBehaviour, IShotComponent
    {
        [SerializeField] private IntEventReceiver moveReceiver;

        public void Shot(int force)
        {
            moveReceiver.Call(force);
        }
    }
}
