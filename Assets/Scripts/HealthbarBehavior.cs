using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{

    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 Offset;
    
    public void SetHealth (float health, float maxHealth)
    {
        float newHealth = health / maxHealth;
        Slider.value = newHealth;
        Slider.maxValue = 1f;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }

    private void FixedUpdate()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
