using Primitives;
using UnityEngine;

namespace Components
{
    public class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField] private IntEventReceiver jumpReceiver;

        public void Jump(int force)
        {
            this.jumpReceiver.Call(force);
        }
    }
}
