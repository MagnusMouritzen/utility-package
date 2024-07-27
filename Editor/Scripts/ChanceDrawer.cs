using UnityEditor;
using UnityEngine;

namespace OK.Utility.Editor {
    [CustomPropertyDrawer(typeof(Chance))]
    public class ChanceDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty chance = property.FindPropertyRelative("chance");
            chance.intValue = EditorGUI.IntSlider(position, label, chance.intValue, 0, 100);
        }
    }
}
