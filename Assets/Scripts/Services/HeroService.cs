using MyEntities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Services
{
    public sealed class HeroService : MonoBehaviour
    {
        [PropertySpace] [ReadOnly] [ShowInInspector]
        private IEntity currentHero;

        public void SetupHero(IEntity hero)
        {
            this.currentHero = hero;
        }

        public IEntity GetHero()
        {
            return this.currentHero;
        }
    }
}