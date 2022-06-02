using UnityEngine;

public class ColorSettingUser : MonoBehaviour {
    public God god;
    private MeshRenderer _meshRenderer;
    public void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update() {
        _meshRenderer.material.color = god.settingsManager.GetColor();
    }
}
