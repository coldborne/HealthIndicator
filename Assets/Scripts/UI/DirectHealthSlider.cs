using UnityEngine.UI;

public class DirectHealthSlider : HealthSlider
{
    protected override void Display(Slider slider, int value)
    {
        slider.value = value;
    }
}
