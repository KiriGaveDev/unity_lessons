using UnityEngine;

namespace Bullets
{
    public sealed class BulletSystem
    {
        private readonly BulletPool _bulletPool;


        public BulletSystem(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }


        public void FlyBulletByArgs(Args args)
        {
            Bullet bullet = _bulletPool.GetBullet();

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            bullet.OnCollisionEntered += OnBulletCollision;
        }


        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            _bulletPool.RemoveBullet(bullet);
        }


        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}