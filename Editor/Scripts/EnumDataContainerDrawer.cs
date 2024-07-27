using UnityEngine;
using UnityEditor;
using System;

namespace OK.Utility.Editor {
    [CustomPropertyDrawer(typeof(EnumDataContainer<,>))]
    public class EnumDataContainerDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            SerializedProperty content = property.FindPropertyRelative("content");
            Type enumType = (fieldInfo.FieldType.IsArray ? fieldInfo.FieldType.GetElementType() : fieldInfo.FieldType)
                .GetGenericArguments()[1];

            float height = EditorGUIUtility.singleLineHeight;
            if (property.isExpanded) {
                if (content.arraySize != enumType.GetEnumNames().Length) {
                    content.arraySize = enumType.GetEnumNames().Length;
                }

                for (int i = 0; i < content.arraySize; i++) {
                    height += EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i));
                }
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty content = property.FindPropertyRelative("content");
            Type enumType = (fieldInfo.FieldType.IsArray ? fieldInfo.FieldType.GetElementType() : fieldInfo.FieldType)
                .GetGenericArguments()[1];

            EditorGUI.BeginProperty(position, label, property);
            Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

            if (property.isExpanded) {
                EditorGUI.indentLevel += 2;
                float addY = EditorGUIUtility.singleLineHeight;
                for (int i = 0; i < content.arraySize; i++) {
                    Rect rect = new Rect(position.x, position.y + addY, position.width,
                        EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i)));
                    addY += rect.height;
                    EditorGUI.PropertyField(rect, content.GetArrayElementAtIndex(i),
                        new GUIContent(enumType.GetEnumNames()[i]), true);
                }

                EditorGUI.indentLevel -= 2;
            }

            EditorGUI.EndProperty();
        }
    }
}
