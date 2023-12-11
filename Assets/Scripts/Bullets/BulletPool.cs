using Level;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Bullets
{
    public class BulletPool : IPauseListener, IResumeListener, IFixedUpdateListener
    {
        private readonly Bullet _prefab;
        private readonly Transform _container;

        private readonly Transform _worldTransform;

        private readonly int _initialCount = 50;
                

        private readonly Queue<Bullet> _bulletPool = new();
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        private readonly LevelBounds _levelBounds;


        [Inject]
        public BulletPool(LevelBounds levelBounds, Bullet prefab, Transform container, Transform worldTransform, int initialCount)
        {
            _levelBounds = levelBounds;
            _prefab = prefab;
            _container = container;
            _worldTransform = worldTransform;
            _initialCount = initialCount;

            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Object.Instantiate(_prefab, container);
                _bulletPool.Enqueue(bullet);
            }
        }

      
        public Bullet GetBullet()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(_worldTransform);
            }
            else
            {
                bullet = Object.Instantiate(_prefab, _worldTransform);
            }

            _activeBullets.Add(bullet);
            return bullet;
        }


        public bool TryRemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(_container);
                _bulletPool.Enqueue(bullet);
                return true;
            }

            return false;
        }


        public void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(_container);
                _bulletPool.Enqueue(bullet);
            }
        }


        public void OnFixedUpdate(float fixedDeltaTime)
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    TryRemoveBullet(bullet);
                }
            }
        }


        public void OnPause()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.PauseMove();
            }
        }


        public void OnResume()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.ResumeMove();
            }
        }
    }
}

