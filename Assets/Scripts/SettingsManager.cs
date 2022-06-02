using UnityEngine;

public class SettingsManager : ScriptableObjectWithOnGameStart {
    [SerializeField] private Color defaultColor;
    private Color _color;
    private const string COLOR_SETTING_PREFS_KEY = "Color";
    private protected override void OnGameStart() {
        _color = defaultColor;
        var s = PlayerPrefs.GetString(COLOR_SETTING_PREFS_KEY, null);
        if (ColorUtility.TryParseHtmlString(s, out var c)) {
            _color = c;
        }
    }
    public Color GetColor() {
        return _color;
    }
    public void SetColor(Color newColor) {
        _color = newColor;
        PlayerPrefs.SetString(COLOR_SETTING_PREFS_KEY, "#" + ColorUtility.ToHtmlStringRGBA(newColor));
        PlayerPrefs.Save();
    }
}
