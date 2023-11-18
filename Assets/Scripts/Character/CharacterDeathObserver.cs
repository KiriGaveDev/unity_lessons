using ShootEmUp;
using UnityEngine;


public class CharacterDeathObserver : MonoBehaviour
{
    [SerializeField] private HitPointsComponent characterHitsComponent;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        characterHitsComponent.OnHpEmpty += CharacterController_OnCharacterDied;
    }


    private void OnDisable()
    {
        characterHitsComponent.OnHpEmpty -= CharacterController_OnCharacterDied;
    }


    private void CharacterController_OnCharacterDied(GameObject gameObject)
    {
        gameManager.FinishGame();
    }
}
