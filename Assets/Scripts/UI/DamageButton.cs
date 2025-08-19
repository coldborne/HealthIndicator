using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : HealthButton
{
    protected override void DoAction(Health health, int amount)
    {
        health.TakeDamage(amount);
    }
}