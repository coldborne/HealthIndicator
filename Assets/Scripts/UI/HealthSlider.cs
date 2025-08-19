using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
        
        _slider.interactable = false;
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        
        DoAction(_health.Value);
    }

    protected virtual void OnEnable()
    {
        _health.ValueChanged += DoAction;
    }

    protected virtual void OnDisable()
    {
        _health.ValueChanged -= DoAction;
    }

    private void DoAction(int value)
    {
        Display(_slider, value);
    }

    protected abstract void Display(Slider slider, int value);
}