using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BPTooltipAttribute))]
public class BPTooltipDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        var atr = (BPTooltipAttribute)attribute;
        var content = new GUIContent(label.text, atr.text);
        EditorGUI.PropertyField(position, prop, content);
    }
}