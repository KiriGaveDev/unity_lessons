using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonChangeName : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private Button button;
    [SerializeField] private List<string> names = new List<string>();

    private UserInfo _userInfo;


    [Inject]
    public void Construct(UserInfo playerLevel)
    {
        _userInfo = playerLevel;
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
        _userInfo.ChangeName(GetRamdomName());
    }


    private string GetRamdomName()
    {
        return names[UnityEngine.Random.Range(0, names.Count)];
    }  
}
