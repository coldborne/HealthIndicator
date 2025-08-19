using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthSlider : HealthSlider
{
    [SerializeField] private float _speed;

    private Coroutine _changingValueCoroutine;

    protected override void OnDisable()
    {
        base.OnDisable();
        
        StopAllCoroutines();

        _changingValueCoroutine = null;
    }

    protected override void Display(Slider slider, int value)
    {
        if (_changingValueCoroutine != null)
        {
            StopCoroutine(_changingValueCoroutine);
        }

        _changingValueCoroutine = StartCoroutine(ChangingValue(slider, value));
    }

    private IEnumerator ChangingValue(Slider slider, float targetValue)
    {
        while (Mathf.Approximately(slider.value, targetValue) == false)
        {
            slider.value = Mathf.MoveTowards(slider.value, targetValue, _speed * Time.unscaledDeltaTime);
            yield return null;
        }

        slider.value = targetValue;
        _changingValueCoroutine = null;
    }
}