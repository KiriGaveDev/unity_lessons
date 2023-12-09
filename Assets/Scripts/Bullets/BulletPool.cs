using Level;
using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;
using static GameListener;

public class BulletPool : MonoBehaviour, IPauseListener, IResumeListener, IFixedUpdateListener
{
    [SerializeField] private int initialCount = 50;

    [SerializeField] private Transform container;
    [SerializeField] private Bullet prefab;
    private LevelBounds _levelBounds;

    [SerializeField] private Transform worldTransform;

    public readonly Queue<Bullet> bulletPool = new();
    public readonly HashSet<Bullet> activeBullets = new();
    public readonly List<Bullet> cache = new();


    private bool isActiveState = false;


    public void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }

    private void Awake()
    {
        for (var i = 0; i < initialCount; i++)
        {
            var bullet = Instantiate(prefab, container);
            bulletPool.Enqueue(bullet);
        }
    }


    public Bullet GetBullet()
    {
        if (bulletPool.TryDequeue(out var bullet))
        {
            bullet.transform.SetParent(worldTransform);
        }
        else
        {
            bullet = Instantiate(prefab, worldTransform);
        }

        return bullet;
    }


    public void RemoveBullet(Bullet bullet)
    {
        if (activeBullets.Remove(bullet))
        {
            bullet.transform.SetParent(container);
            bulletPool.Enqueue(bullet);
        }
    }


    public void OnFixedUpdate(float fixedDeltaTime)
    {
        if (!isActiveState)
        {
            return;
        }

        cache.Clear();
        cache.AddRange(activeBullets);

        for (int i = 0, count = cache.Count; i < count; i++)
        {
            var bullet = cache[i];
            if (!_levelBounds.InBounds(bullet.transform.position))
            {
                RemoveBullet(bullet);
            }
        }
    }


    public void OnPause()
    {
        foreach (var bullet in activeBullets)
        {
            bullet.PauseMove();
        }
    }


    public void OnResume()
    {
        foreach (var bullet in activeBullets)
        {
            bullet.ResumeMove();
        }
    }
}
