using Components;
using Context;
using UnityEngine;

namespace Controllers
{
    public class JumpController : MonoBehaviour, 
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private int force;
        private JumpInput _jumpInput;
        private IJumpComponent _jumpComponent;
        
        void IConstructListener.Construct(GameContext context)
        {
            _jumpComponent = context.GetService<CharacterService>().GetCharacter().Get<IJumpComponent>();
            _jumpInput = context.GetService<JumpInput>();
        }

        void IStartGameListener.OnStartGame()
        {
            _jumpInput.OnJump += Jump;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _jumpInput.OnJump -= Jump;
        }
        
        protected void Jump()
        {
            _jumpComponent.Jump(force);
        }
    }
}
