using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using Bolt.Compiler;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(BoltEventGetData))]
    public class EventGetDataEditor : CustomActionEditor
    {
        BoltEventGetData Action;
        string[] eNames = BPEditorUtils.GetEventNameList().ToArray();

        public override bool OnGUI()
        {
            Action = target as BoltEventGetData; // identify the target action
            Action.targetList = eNames; // update the list
            Action.selectionId = EditorGUILayout.Popup("Event", Action.selectionId, Action.targetList); // update the gui in the editor

            EditField("propNames");
            EditField("storeVariables");

            return true;
        }
    }
}