using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour, IGamePauseListener, IGameStartListener, IGameResumeListener
    {
        [SerializeField] private MoveComponent characterMoveComponent;

        private float horizontalDirection;

        private bool isActiveState = false;


        private void Update()
        {
            if (!isActiveState)
            {
                return;
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
            characterMoveComponent.Move(new Vector2(horizontalDirection, 0) * Time.fixedDeltaTime);
        }

        public void OnPauseGame()
        {
            isActiveState = false;
        }

        public void OnStartGame()
        {
            isActiveState = true;
        }

        public void OnResumeGame()
        {
            isActiveState = true;
        }
    }
}