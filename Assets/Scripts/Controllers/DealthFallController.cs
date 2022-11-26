using Components;
using Context;
using UnityEngine;

namespace Controllers
{
    public class DealthFallController: MonoBehaviour, IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
         private IDealthComponent _dealthComponent;
         private DealthCollision _dealthCollision;
         private GameContext _context;
        void IConstructListener.Construct(GameContext context)
        {
            _dealthComponent = context.GetService<IDealthComponent>();
            _dealthCollision = context.GetService<DealthCollision>();
            _context = context;
        }

        void IStartGameListener.OnStartGame()
        {
            _dealthCollision.OnDealth += Dealth;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _dealthCollision.OnDealth -= Dealth;
        }

        public void Dealth()
        {
            _dealthComponent.Dealth();
            _context.FinishGame();
        }


    }
}