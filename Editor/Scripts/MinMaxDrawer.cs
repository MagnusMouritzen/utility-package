using UnityEngine;
using UnityEditor;

namespace OK.Utility.Editor {
    [CustomPropertyDrawer(typeof(MinMaxInt))]
    public class MinMaxDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            SerializedProperty minProp = property.FindPropertyRelative("min");
            Rect labelRect = new(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
            EditorGUI.LabelField(labelRect, label);
            Rect multiRect = new(position.x + labelRect.width, position.y, position.width - labelRect.width,
                position.height);
            EditorGUI.MultiPropertyField(multiRect, new[] { new GUIContent("Min"), new GUIContent("Max") }, minProp);
            EditorGUI.EndProperty();
        }
    }
}
