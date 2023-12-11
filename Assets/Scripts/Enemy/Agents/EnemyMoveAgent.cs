using ShootEmUp;
using UnityEngine;


namespace Enemies.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private float moveTreshold = 0.25f;

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

            if (vector.sqrMagnitude <= moveTreshold * moveTreshold)
            {
                isReached = true;
                return;
            }

            var direction = vector.normalized * fixedDeltaTime;
            moveComponent.Move(direction);
        }       
    }
}