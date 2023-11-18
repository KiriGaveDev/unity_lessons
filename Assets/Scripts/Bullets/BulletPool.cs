using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int initialCount = 50;

    [SerializeField] private Transform container;
    [SerializeField] private Bullet prefab;
    [SerializeField] private LevelBounds levelBounds;

    public readonly Queue<Bullet> m_bulletPool = new();
    public readonly HashSet<Bullet> m_activeBullets = new();
    public readonly List<Bullet> m_cache = new();

    [SerializeField] private Transform worldTransform;

    private void Awake()
    {
        for (var i = 0; i < this.initialCount; i++)
        {
            var bullet = Instantiate(this.prefab, this.container);
            this.m_bulletPool.Enqueue(bullet);
        }
    }
        

    public Bullet GetBullet()
    {
        if (m_bulletPool.TryDequeue(out var bullet))
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
        if (this.m_activeBullets.Remove(bullet))
        {           
            bullet.transform.SetParent(this.container);
            this.m_bulletPool.Enqueue(bullet);
        }
    }

    private void FixedUpdate()
    {
        this.m_cache.Clear();
        this.m_cache.AddRange(this.m_activeBullets);

        for (int i = 0, count = this.m_cache.Count; i < count; i++)
        {
            var bullet = this.m_cache[i];
            if (!this.levelBounds.InBounds(bullet.transform.position))
            {
                RemoveBullet(bullet);
            }
        }
    }
}
