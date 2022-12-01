using Components;
using Context;
using Mechanics;
using Primitives;
using UnityEngine;

namespace Controllers
{
    public class DealthFallController: MonoBehaviour, IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        private GameContext context;
        private IComponent_TriggerEvents triggerEvent;
         
        void IConstructListener.Construct(GameContext context)
        {
            this.context = context;
            triggerEvent = context.GetService<CharacterService>().GetCharacter().Get<IComponent_TriggerEvents>();
        }

        void IStartGameListener.OnStartGame()
        {
            triggerEvent.OnEntered += Dealth;
        }

        void IFinishGameListener.OnFinishGame()
        {
            triggerEvent.OnEntered += Dealth;
        }

        public void Dealth(Collider other)
        {
            if (other.CompareTag("Dealth"))
                context.FinishGame();
        }
    }
}