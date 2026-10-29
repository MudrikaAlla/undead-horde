using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health targetHealth;
    [SerializeField] private Slider slider;

    void Start()
    {
        targetHealth.OnHealthChanged += UpdateBar;
    }

    void OnDestroy()
    {
        if (targetHealth != null)
            targetHealth.OnHealthChanged -= UpdateBar;
    }

    void UpdateBar(float current, float max)
    {
        slider.value = current / max;
    }
}
