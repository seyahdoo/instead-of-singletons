using UnityEditor;
using UnityEngine;

public abstract class ScriptableObjectWithOnGameStart : ScriptableObject {
    #if UNITY_EDITOR
        private void Awake() {
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
            EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
        }
        private void OnDestroy() {
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
        }
        private void EditorApplicationOnplayModeStateChanged(PlayModeStateChange obj) {
            if (obj == PlayModeStateChange.ExitingEditMode) {
                OnGameStart();
            }
        }
    #endif
    private void OnEnable() {
        OnGameStart();
    }
    private protected abstract void OnGameStart();
}
