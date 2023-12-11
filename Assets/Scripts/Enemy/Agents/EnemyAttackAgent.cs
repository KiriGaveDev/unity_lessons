using Bullets;
using ShootEmUp;
using UnityEngine;


namespace Enemies.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IFixedUpdateListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private Transform target;
        private float currentTime;
        private BulletSystem bulletSystem;


        

        public void Init(BulletSystem bulletSystem, Transform target)
        {
            this.bulletSystem = bulletSystem;
            this.target = target;
        }


        public void Reset()
        {
            currentTime = countdown;
        }


        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (!moveAgent.IsReached)
            {
                return;
            }

            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                Fire();
                currentTime += countdown;
            }
        }


        private void Fire()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2)target.transform.position - startPosition;
            var direction = vector.normalized;

            OnFire(startPosition, direction);
        }


        private void OnFire(Vector2 position, Vector2 direction)
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}