using UnityEngine;

public class CharacterAttackController: MonoBehaviour
{
    [SerializeField] private CharacterAttackComponent characterAttackComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterAttackComponent.Fire();
        }
    }
}
