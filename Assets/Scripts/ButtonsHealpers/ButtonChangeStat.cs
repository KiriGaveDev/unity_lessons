using Character;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonChangeStat : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private Button button;
    [SerializeField] private string statName;
    [SerializeField] private int changeValue;
       
    private Character.CharacterInfo _characterInfo;


    [Inject]
    public void Construct(Character.CharacterInfo characterInfo)
    {
        _characterInfo = characterInfo;     
    }


    public void Initialize()
    {
        button.onClick.AddListener(OnClick);
    }


    public void Dispose()
    {
        button.onClick.RemoveListener(OnClick);
    }


    private void OnClick()
    {
        CharacterStat stat = _characterInfo.GetStat(statName);
        stat.ChangeValue(changeValue);
    }

}
