using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;
using static GameListener;

public class BulletPool : MonoBehaviour, IPauseListener, IResumeListener
{
    [SerializeField] private int initialCount = 50;

    [SerializeField] private Transform container;
    [SerializeField] private Bullet prefab;
    [SerializeField] private LevelBounds levelBounds;

    [SerializeField] private Transform worldTransform;

    public readonly Queue<Bullet> bulletPool = new();
    public readonly HashSet<Bullet> activeBullets = new();
    public readonly List<Bullet> cache = new();
    

    private bool isActiveState = false;


    private void Awake()
    {
        for (var i = 0; i < this.initialCount; i++)
        {
            var bullet = Instantiate(this.prefab, this.container);
            this.bulletPool.Enqueue(bullet);
        }
    }
        

    public Bullet GetBullet()
    {
        if (bulletPool.TryDequeue(out var bullet))
        {
            bullet.transform.SetParent(this.worldTransform);
        }
        else
        {
            bullet = Instantiate(this.prefab, this.worldTransform);
        }

        return bullet;
    }


    public void RemoveBullet(Bullet bullet)
    {
        if (activeBullets.Remove(bullet))
        {           
            bullet.transform.SetParent(this.container);
            this.bulletPool.Enqueue(bullet);
        }
    }


    private void FixedUpdate()
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
            if (!levelBounds.InBounds(bullet.transform.position))
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
