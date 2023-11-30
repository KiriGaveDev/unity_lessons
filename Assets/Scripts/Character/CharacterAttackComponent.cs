using ShootEmUp;
using UnityEngine;

public class CharacterAttackComponent : MonoBehaviour
{
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private BulletSystem bulletSystem;
    [SerializeField] private BulletConfig bulletConfig;

     
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

