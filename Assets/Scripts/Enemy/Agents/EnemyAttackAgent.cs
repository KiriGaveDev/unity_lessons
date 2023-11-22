using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
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
            this.currentTime = this.countdown;
        }

        private void FixedUpdate()
        {
            if (!this.moveAgent.IsReached)
            {
                return;
            }
                       
            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this.countdown;
            }
        }

        private void Fire()
        {
            var startPosition = this.weaponComponent.Position;
            var vector = (Vector2) this.target.transform.position - startPosition;
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