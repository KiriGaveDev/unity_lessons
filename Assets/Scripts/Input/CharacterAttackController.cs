using UnityEngine;
using static GameListener;

public class CharacterAttackController: MonoBehaviour, IGamePauseListener, IGameStartListener, IGameResumeListener
{
    [SerializeField] private CharacterAttackComponent characterAttackComponent;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            characterAttackComponent.Fire();
        }
    }

    public void OnPauseGame()
    {
        enabled = false;
    }

    public void OnResumeGame()
    {
        enabled = true;
    }

    public void OnStartGame()
    {
        enabled = true;
    }

  
}
