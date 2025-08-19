using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _maxHealthText;
    
    [SerializeField] private Health _health;

    private void Start()
    {
        _healthText.text = _health.Value.ToString();
        _maxHealthText.text = _health.MaxValue.ToString();
    }

    private void OnEnable()
    {
        _health.ValueChanged += Display;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= Display;
    }

    public void Display(int value)
    {
        _healthText.text = value.ToString();
    }
}
