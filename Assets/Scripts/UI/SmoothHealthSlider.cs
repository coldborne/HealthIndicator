using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthSlider : HealthSlider
{
    [SerializeField] private float _durationTime;

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
        float startValue = slider.value;
        float elapsedTime = 0f;

        float progress;
        
        while (elapsedTime < _durationTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
            
            progress = Mathf.Clamp01(elapsedTime / _durationTime);
            slider.value = Mathf.Lerp(startValue, targetValue, progress);
            yield return null;
        }

        slider.value = targetValue;
        _changingValueCoroutine = null;
    }
}