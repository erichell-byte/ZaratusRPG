using Components;
using UnityEngine;
using Entities;

namespace Controllers
{
    public class ShotController : AbstractShotController
    {
        [SerializeField] private Entity unit;

        [SerializeField] private int force;

        private IShotComponent _shotComponent;
        private void Awake()
        {
            _shotComponent = unit.Get<IShotComponent>();
        }

        protected override void Shot()
        {
            _shotComponent.Shot(force);
        }
    }
}
