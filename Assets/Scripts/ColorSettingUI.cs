using UnityEngine;
using UnityEngine.UI;

public class ColorSettingUI : MonoBehaviour {
    public God god;
    public Slider rSlider;
    public Slider gSlider;
    public Slider bSlider;
    public Slider aSlider;
    public Toggle overrideToggle;
    
    private void OnEnable() {
        var color = god.settingsManager.GetColor();
        rSlider.onValueChanged.AddListener(OnSliderValueChanged);
        gSlider.onValueChanged.AddListener(OnSliderValueChanged);
        bSlider.onValueChanged.AddListener(OnSliderValueChanged);
        aSlider.onValueChanged.AddListener(OnSliderValueChanged);
        rSlider.value = color.r;
        gSlider.value = color.g;
        bSlider.value = color.b;
        aSlider.value = color.a;
        
        var willOverride = god.settingsManager.GetWillColorOverride();
        overrideToggle.onValueChanged.AddListener(OnToggleValueChanged);
        overrideToggle.isOn = willOverride;
    }
    private void OnDisable() {
        rSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        gSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        bSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        aSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        overrideToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
    private void OnToggleValueChanged(bool willOverride) {
        var color = new Color(
            rSlider.value,
            gSlider.value,
            bSlider.value,
            aSlider.value
        );
        god.settingsManager.SetColorWillOverride(willOverride, color);
    }
    private void OnSliderValueChanged(float newSliderValue) {
        if (overrideToggle.isOn) {
            var color = new Color(
                rSlider.value,
                gSlider.value,
                bSlider.value,
                aSlider.value
            );
            god.settingsManager.SetOverrideColor(color);
        }
    }
}
