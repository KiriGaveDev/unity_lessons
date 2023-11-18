using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        public static Action OnCharacterDied;      
     
        [SerializeField] private HitPointsComponent hitPointsComponent;   
             

        private void OnEnable()
        {
            hitPointsComponent.OnHpEmpty += HitPointsComponent_HpEmpty;
        }

        private void OnDisable()
        {
            hitPointsComponent.OnHpEmpty -= HitPointsComponent_HpEmpty;
        }

      
        private void HitPointsComponent_HpEmpty(GameObject gameObject)
        {
            OnCharacterDied?.Invoke();
        }       
    }
}