using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonChangeDescription : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private Button button;
    [SerializeField] private List<string> descritions = new List<string>();

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
        _userInfo.ChangeDescription(GetRamdomDescription());
    }


    private string GetRamdomDescription()
    {
        return descritions[UnityEngine.Random.Range(0, descritions.Count)];
    }
}