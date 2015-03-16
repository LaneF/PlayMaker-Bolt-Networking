using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class MyEditorWindow : EditorWindow
{
    private string[] options = new string[] { "0.1", "0.2", "0.3" };
    private int index = 0;

    [MenuItem("Examples/ApplyZ")]

    void Init()
    {
        MyEditorWindow window = (MyEditorWindow)EditorWindow.GetWindow(typeof(MyEditorWindow));
    }

    void OnGUI()
    {
        index = EditorGUILayout.Popup(index, options);
        if (GUILayout.Button("Apply"))
            Apply();
    }

    void Apply()
    {
        float newZ = float.Parse(options[index]);

        if (Selection.transforms.Length == 0)
            EditorUtility.DisplayDialog("No Selected Transforms", "To use ApplyZ you have to select one or more Transform", "Ok");

        foreach (Transform oneTrans in Selection.transforms)
        {
            Vector3 pos = oneTrans.position;
            oneTrans.position = new Vector3(pos.x, pos.y, newZ);
        }
    }
}