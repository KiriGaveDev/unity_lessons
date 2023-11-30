using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;

        private Vector2 destination;
        private bool isReached;

        public bool IsReached => isReached;
        

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isReached = false;
        }


        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (isReached)
            {
                return;
            }
            
            var vector = destination - (Vector2)transform.position;

            if (vector.magnitude <= 0.25f)
            {
                isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            moveComponent.Move(direction);
        }       
    }
}