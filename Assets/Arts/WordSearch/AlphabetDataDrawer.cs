using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;


[CustomEditor(typeof(AlphabetDataDrawer))]
[CanEditMultipleObjects]
[System.Serializable]
public class AlphabetDataDrawer : Editor
{
    private ReorderableList AlphabetPlainLists;
    private ReorderableList AlphabetNormalLists;
    private ReorderableList AlphabetHighlightedLists;
    private ReorderableList AlphabetWrongLists;

    private void OnEnable()
    {
        InitializeReordableList(ref AlphabetPlainLists, "AlphabetPlain", "Alphabet Plain");
        InitializeReordableList(ref AlphabetPlainLists, "AlphabetNormal", "Alphabet Normal");
        InitializeReordableList(ref AlphabetPlainLists, "AlphabetHighlighted", "Alphabet Highlighted");
        InitializeReordableList(ref AlphabetPlainLists, "AlphabetWrong", "Alphabet Wrong");

    }

    public override void OnInspectorGUI()
    {
       serializedObject.Update();
        AlphabetPlainLists.DoLayoutList();
        AlphabetNormalLists.DoLayoutList();
        AlphabetHighlightedLists.DoLayoutList();
        AlphabetWrongLists.DoLayoutList();

        serializedObject.ApplyModifiedProperties();

    }
    private void InitializeReordableList(ref ReorderableList list, string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName),
            true, true, true, true);

        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, listLabel);
        };

        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive,bool isFocused) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("letter"), GUIContent.none);

            EditorGUI.PropertyField(
                new Rect(rect.x + 70, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("image"), GUIContent.none);
        };
    }
}
#endif
