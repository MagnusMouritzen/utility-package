using UnityEditor;
using UnityEngine;

namespace OK.Utility.Editor {
    [CustomPropertyDrawer(typeof(SelectionOption<>))]
    public class SelectionOptionDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            SerializedProperty option = property.FindPropertyRelative("option");
            SerializedProperty relativeChance = property.FindPropertyRelative("relativeChance");
            return EditorGUI.GetPropertyHeight(option) + EditorGUI.GetPropertyHeight(relativeChance);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty option = property.FindPropertyRelative("option");
            Rect optionRect = new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(option));
            EditorGUI.PropertyField(optionRect, option, label, true);

            SerializedProperty relativeChance = property.FindPropertyRelative("relativeChance");
            Rect relativeChanceRect = new Rect(position.x, position.y + optionRect.height, position.width,
                EditorGUI.GetPropertyHeight(relativeChance));
            if (relativeChance.floatValue <= 0f) relativeChance.floatValue = 1f;
            EditorGUI.PropertyField(relativeChanceRect, relativeChance, true);
        }
    }
}
