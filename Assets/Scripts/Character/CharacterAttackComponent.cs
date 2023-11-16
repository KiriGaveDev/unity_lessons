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
            physicsLayer = (int)this.bulletConfig.physicsLayer,
            color = this.bulletConfig.color,
            damage = this.bulletConfig.damage,
            position = weaponComponent.Position,
            velocity = weaponComponent.Rotation * Vector3.up * this.bulletConfig.speed
        });
    }   
}

