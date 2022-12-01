using UnityEngine;
using Components;
using Context;

namespace Controllers
{
    public class MoveController : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private float speed;
        
        private AxisInput _input;
        private IMoveComponent _moveComponent;
        private Vector3 _direction;
        
        void IConstructListener.Construct(GameContext context)
        {
            _input = context.GetService<AxisInput>();
            _moveComponent = context.GetService<CharacterService>()
                .GetCharacter()
                .Get<IMoveComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            _input.OnMove += Move;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnMove -= Move;
        }
        
        protected void Move(Vector3 direction)
        {
            var velocity = (speed * Time.deltaTime) * direction;
            _moveComponent.Move(velocity);
        }
    }
}
