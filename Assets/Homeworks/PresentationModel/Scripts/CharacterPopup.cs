using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterPopup : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] private Slider expereinceSlider;
    [SerializeField] private TextMeshProUGUI experienceTxt;

    private PlayerLevel playerLevel;

    [Inject]
    public void Construct(PlayerLevel playerLevel)
    {
        this.playerLevel = playerLevel;

    }


    public void SetExperienceValue(float current, float target)
    {
        expereinceSlider.maxValue = target;
        expereinceSlider.value = current;

        experienceTxt.text = $"XP : {current / target}";
    }
}
