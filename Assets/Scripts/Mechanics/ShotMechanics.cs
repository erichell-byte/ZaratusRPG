using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class ShotMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver shotSignal;
        [SerializeField] private BulletCreator bulletCreator;
        
        private void OnEnable()
        {
            shotSignal.OnEvent += OnShot;
        }

        private void OnDisable()
        {
            shotSignal.OnEvent -= OnShot;
        }
        
        private void OnShot(int force)
        {
            var newBullet = bulletCreator.CreateBullet();
            if (newBullet.TryGetComponent(out Rigidbody bulletRb))
                bulletRb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }

    


}
