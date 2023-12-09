using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterPopup : MonoBehaviour, IInitializable
{
    [Header("Experience")]
    [SerializeField] private Slider expereinceSlider;
    [SerializeField] private TextMeshProUGUI experienceTxt;

    private PlayerLevel playerLevel;

    [Inject]
    public void Construct(PlayerLevel playerLevel)
    {
        Debug.Log("конструктор");
        this.playerLevel = playerLevel;
    }


    public void Initialize()
    {
        Debug.Log("инит");
        playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
    }


    public void Deinizialize()
    {
        playerLevel.OnExperienceChanged -= PlayerLevel_OnExperienceChanged;
    }


    private void PlayerLevel_OnExperienceChanged(int changedValue)
    {       
        SetExperienceValue(playerLevel.CurrentExperience, playerLevel.RequiredExperience, changedValue);
    }


    public void SetExperienceValue(int current, int target, int changedValue)
    {
        expereinceSlider.maxValue = target;
        expereinceSlider.value = current;

        experienceTxt.text = $"XP : {current / target}";
    }

   
}
