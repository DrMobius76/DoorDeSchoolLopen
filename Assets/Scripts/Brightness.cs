using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Image brightnessOverlay; // Sleep je zwarte Image hierheen in de Inspector
    public Slider brightnessSlider; // Sleep je slider hierheen in de Inspector

    void OnAwake()
    {
        // Stel de sliderwaarde in (1 = volledig helder, 0 = volledig donker)
        brightnessSlider.value = 0.8f;
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        Debug.Log(value);
        // Pas de Alpha aan van het zwarte overlay
        Color overlayColor = brightnessOverlay.color;
        overlayColor.a = 1 - value; // 1 = volledig helder, 0 = volledig donker
        brightnessOverlay.color = overlayColor;
    }
}
