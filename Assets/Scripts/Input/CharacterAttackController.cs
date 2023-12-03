using ShootEmUp;
using UnityEngine;
using Zenject;
using static GameListener;

public class CharacterAttackController : IUpdateListener
{
    private CharacterAttackComponent characterAttackComponent;


    [Inject]
    public CharacterAttackController(CharacterAttackComponent characterAttackComponent, GameManager gameManager)
    {        
        this.characterAttackComponent = characterAttackComponent;
        gameManager.AddListener(this);
    }


    public void OnUpdate(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            characterAttackComponent.Fire();
        }
    }
}
