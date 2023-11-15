using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        private float horizontalDirection;

        [SerializeField]
        private MoveComponent characterMoveComponent;

        [SerializeField]
        private CharacterAttackComponent characterAttackComponent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterAttackComponent.Fire();
            }           

            if (Input.GetKey(KeyCode.A))
            {
                horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontalDirection = 1;
            }
            else
            {
                horizontalDirection = 0;
            }
        }

        private void FixedUpdate()
        {
            characterMoveComponent.MoveByRigidbodyVelocity(new Vector2(horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}