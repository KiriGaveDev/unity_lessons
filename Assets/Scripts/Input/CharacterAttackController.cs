using UnityEngine;
using static GameListener;

public class CharacterAttackController: MonoBehaviour, IPauseListener, IStartListener, IResumeListener
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

    public void OnPause()
    {
        enabled = false;
    }

    public void OnResume()
    {
        enabled = true;
    }

    public void OnStart()
    {
        enabled = true;
    }

  
}
