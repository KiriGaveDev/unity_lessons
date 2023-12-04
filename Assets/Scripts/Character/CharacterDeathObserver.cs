using ShootEmUp;
using UnityEngine;
using Zenject;

public class CharacterDeathObserver : IInitializable
{
    private HitPointsComponent characterHitsComponent;
    private GameManager gameManager;


    [Inject]
    public CharacterDeathObserver(HitPointsComponent characterHitsComponent, GameManager gameManager)
    {
        this.characterHitsComponent = characterHitsComponent;
        this.gameManager = gameManager;
    }

  
    private void CharacterController_OnCharacterDied(GameObject gameObject)
    {
        gameManager.FinishGame();
        characterHitsComponent.OnHpEmpty -= CharacterController_OnCharacterDied;
    }

    public void Initialize()
    {       
        characterHitsComponent.OnHpEmpty += CharacterController_OnCharacterDied;
    }   
}
