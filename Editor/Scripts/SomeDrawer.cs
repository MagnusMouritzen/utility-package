using UnityEngine;
using UnityEditor;

namespace OK.Utility.Editor {
    [CustomPropertyDrawer(typeof(Some<>), true)]
    public class SomeDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            SerializedProperty isSome = property.FindPropertyRelative("isSome");
            SerializedProperty value = property.FindPropertyRelative("_value");
            return EditorGUI.GetPropertyHeight(isSome) + (isSome.boolValue ? EditorGUI.GetPropertyHeight(value) : 0);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // TODO: Make it optional to get the value dropdown
            SerializedProperty isSome = property.FindPropertyRelative("isSome");
            Rect isSomeRect = new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(isSome));
            EditorGUI.PropertyField(isSomeRect, isSome, label);

            if (!isSome.boolValue) return;
            EditorGUI.indentLevel++;
            SerializedProperty value = property.FindPropertyRelative("_value");
            Rect valueRect = new Rect(position.x, position.y + isSomeRect.height, position.width,
                EditorGUI.GetPropertyHeight(value));
            EditorGUI.PropertyField(valueRect, value, true);
            EditorGUI.indentLevel--;
        }
    }
}
