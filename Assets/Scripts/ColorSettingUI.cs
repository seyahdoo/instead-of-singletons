using UnityEngine;
using UnityEngine.UI;

public class ColorSettingUI : MonoBehaviour {
    public God god;
    public Slider rSlider;
    public Slider gSlider;
    public Slider bSlider;
    public Slider aSlider;
    private Color _color;
    private Color _oldColor;
    private void Awake() {
        _color = god.settingsManager.GetColor();
        _oldColor = _color;
        rSlider.value = _color.r;
        gSlider.value = _color.g;
        bSlider.value = _color.b;
        aSlider.value = _color.a;
    }
    private void Update() {
        _color.r = rSlider.value;
        _color.g = gSlider.value;
        _color.b = bSlider.value;
        _color.a = aSlider.value;
        if (_oldColor != _color) {
            _oldColor = _color;
            god.settingsManager.SetColor(_color);
        }
    }
}
