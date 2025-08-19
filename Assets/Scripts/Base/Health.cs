using System;
using UnityEngine;


public class Health : MonoBehaviour, IDamageable, IMedicinable
{
    private readonly int _minValue = 0;
    private readonly int _maxValue = 100;

    public event Action Died;
    public event Action<int> ValueChanged;

    private void Awake()
    {
        Value = _maxValue;
        ValueChanged?.Invoke(Value);
    }
    
    public int MinValue => _minValue;
    public int MaxValue => _maxValue;
    public int Value { get; private set; }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("amount must be greater than zero");
        }

        int newValue = Value - amount;
        
        if (newValue > _minValue)
        {
            Value = newValue;
        }
        else
        {
            Value = _minValue;
            Died?.Invoke();
        }
        
        ValueChanged?.Invoke(Value);
    }

    public void Treat(int amount)
    {
        if (amount <= _minValue)
        {
            throw new ArgumentOutOfRangeException("amount must be greater than zero");
        }

        int newValue = Value + amount;

        Value = newValue < _maxValue ? newValue : _maxValue;
        
        ValueChanged?.Invoke(Value);
    }
}