using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class CharacterMoveController :         
        IFixedUpdateListener,
        IUpdateListener

    {

        private MoveComponent characterMoveComponent;

        private float horizontalDirection;


        public CharacterMoveController(MoveComponent characterMoveComponent, GameManager gameManager)
        {
            this.characterMoveComponent = characterMoveComponent;
            gameManager.AddListener(this);
        }


        public void OnFixedUpdate(float fixedDeltaTime)
        {
            characterMoveComponent.Move(new Vector2(horizontalDirection, 0) * fixedDeltaTime);
        }


        public void OnUpdate(float deltaTime)
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
    }
}