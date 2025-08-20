using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected int MinHealthValue => _health.MinValue;
    protected int MaxHealthValue => _health.MaxValue;
    protected int HealthValue => _health.Value;

    private void OnEnable()
    {
        _health.ValueChanged += DoAction;
    }

    protected virtual void OnDisable()
    {
        _health.ValueChanged -= DoAction;
    }

    protected abstract void DoAction(int value);
}