using ShootEmUp;
using UnityEngine;
using Zenject;

public class CharacterAttackAgent
{
    private WeaponComponent weaponComponent;
    private BulletSystem bulletSystem;
    private BulletConfig bulletConfig;


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

