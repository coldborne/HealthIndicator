using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthSlider : HealthView
{
    private Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.interactable = false;
        _slider.minValue = MinHealthValue;
        _slider.maxValue = MaxHealthValue;

        _slider.value = HealthValue;
    }

    protected override void DoAction(int value)
    {
        Display(_slider, value);
    }

    protected abstract void Display(Slider slider, int value);
}