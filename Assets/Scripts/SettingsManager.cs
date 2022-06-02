using UnityEngine;

public class SettingsManager : ScriptableObject {
    private const string COLOR_SETTING_PREFS_KEY = "Color";
    [SerializeField] private Color defaultColor;
    private Color _overridenColorCache;
    private bool _overridingColor;
    private void Awake() {
        Debug.Log("awake");
        var s = PlayerPrefs.GetString(COLOR_SETTING_PREFS_KEY, null);
        _overridingColor = ColorUtility.TryParseHtmlString(s, out var c);
        _overridenColorCache = c;
    }
    public Color GetColor() {
        if (_overridingColor) {
            return _overridenColorCache;
        }
        else {
            return defaultColor;
        }
    }
    public void SetOverrideColor(Color newColor) {
        _overridenColorCache = newColor;
        PlayerPrefs.SetString(COLOR_SETTING_PREFS_KEY, "#" + ColorUtility.ToHtmlStringRGBA(newColor));
        PlayerPrefs.Save();
    }
    public void SetColorWillOverride(bool willOverride, Color newColor) {
        _overridingColor = willOverride;
        if (willOverride) {
            _overridenColorCache = newColor;
            PlayerPrefs.SetString(COLOR_SETTING_PREFS_KEY, "#" + ColorUtility.ToHtmlStringRGBA(newColor));
            PlayerPrefs.Save();
        }
        else {
            PlayerPrefs.DeleteKey(COLOR_SETTING_PREFS_KEY);
            PlayerPrefs.Save();
        }
    }
    public bool GetWillColorOverride() {
        return PlayerPrefs.HasKey(COLOR_SETTING_PREFS_KEY);
    }
}
