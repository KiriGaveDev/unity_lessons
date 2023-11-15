using ShootEmUp;
using UnityEngine;

public class CharacterAttackComponent : MonoBehaviour
{
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private BulletSystem _bulletSystem;
    [SerializeField] private BulletConfig _bulletConfig;

     
    public void Fire()
    {
        _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
        {
            isPlayer = true,
            physicsLayer = (int)this._bulletConfig.physicsLayer,
            color = this._bulletConfig.color,
            damage = this._bulletConfig.damage,
            position = weaponComponent.Position,
            velocity = weaponComponent.Rotation * Vector3.up * this._bulletConfig.speed
        });
    }   
}

