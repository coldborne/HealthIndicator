using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButton : HealthButton
{
    protected override void DoAction(Health health, int amount)
    {
        health.Treat(amount);
    }
}