using UnityEngine;

namespace Controllers
{
    public abstract class AbstractMoveController : MonoBehaviour
    {
        private void Update()
        {
            HandleInput();
        }
        
        private void HandleInput()
        {
            //  в разы больше вызовов метода Move, чем ваша реализация, это критично?
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (direction != Vector3.zero)
                Move(direction);
        }

        protected abstract void Move(Vector3 direction);
    }
}