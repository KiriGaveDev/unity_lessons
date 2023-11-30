using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour, IPauseListener, IStartListener, IResumeListener
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

        public void OnPause()
        {
            enabled = false;
        }

        public void OnStart()
        {
            enabled = true;
        }

        public void OnResume()
        {
            enabled = true;
        }
    }
}