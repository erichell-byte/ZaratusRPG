using UnityEngine;

namespace Controllers
{
    public abstract class AbstractJumpController : MonoBehaviour
    {
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        protected abstract void Jump();


    }
}
