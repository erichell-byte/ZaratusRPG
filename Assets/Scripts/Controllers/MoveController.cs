using UnityEngine;
using Components;
using Entities;

namespace Controllers
{
    public class MoveController : AbstractMoveController
    {
        [SerializeField] private Entity unit;
        [SerializeField] private float speed;
        private IMoveComponent _moveComponent;
        private Vector3 _direction;

        private void Awake()
        {
            _moveComponent = unit.Get<IMoveComponent>();
        }
        
        protected override void Move(Vector3 direction)
        {
            var velocity = (speed * Time.deltaTime) * direction;
            _moveComponent.Move(velocity);
        }
    }
}
