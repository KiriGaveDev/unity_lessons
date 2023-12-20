using TMPro;
using UnityEngine;


public class CharacterStatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statNameTxt;
    [SerializeField] private TextMeshProUGUI statValueTxt;

    private string _statName;

    public string StatName => _statName;

    public void Initialize(string statName, int statValue)
    {
        _statName = statName;

        statNameTxt.text = statName;
        SetValue(statValue);
    }


    public void SetValue(int value)
    {
        statValueTxt.text = value.ToString();
    }
}
