using Components;
using Context;
using UnityEngine;

namespace Controllers
{
    public class ShotController: MoveController,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private int force;
        private IShotComponent _shotComponent;
        private MouseInput _input;
        
        protected void Shot()
        {
            _shotComponent.Shot(force);
        }

        void IConstructListener.Construct(GameContext context)
        {
            _shotComponent = context.GetService<IShotComponent>();
            _input = context.GetService<MouseInput>();
        }

        void IStartGameListener.OnStartGame()
        {
            _input.OnClick += Shot;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnClick -= Shot;
        }
    }
}
