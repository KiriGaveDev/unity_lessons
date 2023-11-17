using ShootEmUp;
using UnityEngine;


public class CharacterDeathObserver : MonoBehaviour
{
    [SerializeField] private HitPointsComponent characterHitsComponent;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        characterHitsComponent.hpEmpty += CharacterController_OnCharacterDied;
    }


    private void OnDisable()
    {
        characterHitsComponent.hpEmpty -= CharacterController_OnCharacterDied;
    }


    private void CharacterController_OnCharacterDied(GameObject gameObject)
    {
        gameManager.FinishGame();
    }
}
