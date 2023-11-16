using ShootEmUp;
using UnityEngine;

public class CharacterAttackComponent : MonoBehaviour
{
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private BulletSystem bulletSystem;
    [SerializeField] private BulletConfig bulletConfig;

     
    public void Fire()
    {
        bulletSystem.Fire(bulletConfig, weaponComponent);
    }   
}

