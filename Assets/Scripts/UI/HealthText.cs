using TMPro;
using UnityEngine;

public class HealthText : HealthView
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _maxHealthText;

    private void Start()
    {
        _healthText.text = HealthValue.ToString();
        _maxHealthText.text = MaxHealthValue.ToString();
    }

    protected override void DoAction(int value)
    {
        Display(value);
    }

    private void Display(int value)
    {
        _healthText.text = value.ToString();
    }
}