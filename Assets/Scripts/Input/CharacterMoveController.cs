using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour, IGamePauseListener, IGameStartListener, IGameResumeListener
    {
        [SerializeField] private MoveComponent characterMoveComponent;

        private float horizontalDirection;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {            

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
            enabled = false;
        }

        public void OnStartGame()
        {
            enabled = true;
        }

        public void OnResumeGame()
        {
            enabled = true;
        }
    }
}