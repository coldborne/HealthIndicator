using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Slider _slider;
    private Coroutine _changingValueCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        
        _slider.interactable = false;
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;

        _slider.value = _health.Value;
    }

    private void OnEnable()
    {
        _health.ValueChanged += Display;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= Display;

        StopAllCoroutines();
        
        _changingValueCoroutine = null;
    }

    private void Display(int value)
    {
        if (_changingValueCoroutine != null)
        {
            StopCoroutine(_changingValueCoroutine);
        }

        _changingValueCoroutine = StartCoroutine(ChangingValue(value));
    }

    private IEnumerator ChangingValue(float targetValue)
    {
        while (Mathf.Approximately(_slider.value, targetValue) == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.unscaledDeltaTime);
            yield return null;
        }

        _slider.value = targetValue;
        _changingValueCoroutine = null;
    }
}