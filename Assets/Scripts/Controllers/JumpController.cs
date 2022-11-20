using Components;
using UnityEngine;
using Entities;

namespace Controllers
{
    public class JumpController : AbstractJumpController
    {
        [SerializeField] private Entity unit;
        [SerializeField] private int force;
        private IJumpComponent _jumpComponent;
        
        private void Awake()
        {
            _jumpComponent = unit.Get<IJumpComponent>();
        }

        protected override void Jump()
        {
            _jumpComponent.Jump(force);
        }
        
        
    }
}
