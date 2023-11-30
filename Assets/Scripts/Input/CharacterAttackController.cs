using UnityEngine;
using static GameListener;

public class CharacterAttackController: MonoBehaviour, IUpdateListener
{
    [SerializeField] private CharacterAttackComponent characterAttackComponent;
        

    public void OnUpdate(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            characterAttackComponent.Fire();
        }
    }
}
