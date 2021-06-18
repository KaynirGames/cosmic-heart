using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(VariableReferenceWrapper), true)]
public class VariableReferenceDrawer : PropertyDrawer
{
    protected string[] _popupOptions = new string[] { "Constant", "Variable" };

    protected GUIStyle popupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupStyle == null)
        {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        SerializedProperty constantValue = property.FindPropertyRelative("_constantValue");
        SerializedProperty variable = property.FindPropertyRelative("_variable");
        SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");

        Rect buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, _popupOptions, popupStyle);

        useConstant.boolValue = result == 0;

        EditorGUI.PropertyField(position,
                                useConstant.boolValue ? constantValue : variable,
                                GUIContent.none);

        if (EditorGUI.EndChangeCheck())
        {
            property.serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}