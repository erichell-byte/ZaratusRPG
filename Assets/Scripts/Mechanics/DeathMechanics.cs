using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class DeathMechanics : MonoBehaviour
    {
        [SerializeField] private IntBehaviour hitPoints;

        [SerializeField] private EventReceiver deathReceiver;

        private void OnEnable()
        {
            hitPoints.OnValueChanged += OnHitPointsChanged;
        }

        private void OnDisable()
        {
            hitPoints.OnValueChanged -= OnHitPointsChanged;
        }


        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                this.deathReceiver.Call();
            }
        }
    }
}
