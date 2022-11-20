using UnityEngine;

namespace Controllers
{
    public abstract class AbstractShotController : MonoBehaviour
    {
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Shot();
        }

        protected abstract void Shot();
    }
}