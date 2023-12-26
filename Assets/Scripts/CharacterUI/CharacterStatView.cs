using TMPro;
using UnityEngine;


public class CharacterStatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statNameTxt;
    [SerializeField] private TextMeshProUGUI _statValueTxt;

    private string _statName;

    public string StatName => _statName;

    public void Initialize(string statName, int statValue)
    {
        _statName = statName;

        _statNameTxt.text = statName;
        SetValue(statValue);
    }


    public void SetValue(int value)
    {
        _statValueTxt.text = value.ToString();
    }
}
