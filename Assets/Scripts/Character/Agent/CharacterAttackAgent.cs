using Bullets;
using ShootEmUp;
using UnityEngine;
using Zenject;

public class CharacterAttackAgent
{
    private readonly WeaponComponent weaponComponent;
    private readonly BulletSystem bulletSystem;
    private readonly BulletConfig bulletConfig;


    [Inject]
    public CharacterAttackAgent(WeaponComponent weaponComponent, BulletSystem bulletSystem, BulletConfig bulletConfig)
    {
        this.weaponComponent = weaponComponent;
        this.bulletSystem = bulletSystem;
        this.bulletConfig = bulletConfig;
    }


    public void Fire()
    {
        bulletSystem.FlyBulletByArgs(new BulletSystem.Args
        {
            isPlayer = true,
            physicsLayer = (int)bulletConfig.physicsLayer,
            color = bulletConfig.color,
            damage = bulletConfig.damage,
            position = weaponComponent.Position,
            velocity = weaponComponent.Rotation * Vector3.up * bulletConfig.speed
        });
    }
}

