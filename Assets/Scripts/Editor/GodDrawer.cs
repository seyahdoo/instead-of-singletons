using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(God))]
public class GodDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if (property.objectReferenceValue == null) {
            var guids = AssetDatabase.FindAssets($"t:{nameof(God)}");
            if (guids.Length != 1) {
                Debug.LogError("There is more than one GOD, Impossible!!! o_o");
                return;
            }
            var god = AssetDatabase.LoadAssetAtPath<God>(AssetDatabase.GUIDToAssetPath(guids[0]));
            property.objectReferenceValue = god;               
        }
        using (new EditorGUI.PropertyScope(position, label, property)) {
            using (new EditorGUI.DisabledGroupScope(true)) {
                EditorGUI.PropertyField(position, property, label);
            }    
        }
    }
}