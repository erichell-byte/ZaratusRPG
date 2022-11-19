using UnityEngine;

namespace Mechanics
{
    public sealed class BulletCreator : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform shotPoint;

        public GameObject CreateBullet()
        {
            return Instantiate(bullet, shotPoint.position, Quaternion.identity);
        }

    }
}