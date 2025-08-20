using System;
using UnityEngine;


public class Health : MonoBehaviour, IDamageable, IMedicinable
{
    public event Action Died;
    public event Action<int> ValueChanged;

    public int MinValue { get; }
    public int MaxValue { get; } = 100;
    public int Value { get; private set; }

    private void Awake()
    {
        Value = MaxValue;
        ValueChanged?.Invoke(Value);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("amount must be greater than zero");
        }

        int newValue = Value - amount;

        if (newValue > MinValue)
        {
            Value = newValue;
        }
        else
        {
            Value = MinValue;
            Died?.Invoke();
        }

        ValueChanged?.Invoke(Value);
    }

    public void Treat(int amount)
    {
        if (amount <= MinValue)
        {
            throw new ArgumentOutOfRangeException("amount must be greater than zero");
        }

        int newValue = Value + amount;

        Value = newValue < MaxValue ? newValue : MaxValue;

        ValueChanged?.Invoke(Value);
    }
}