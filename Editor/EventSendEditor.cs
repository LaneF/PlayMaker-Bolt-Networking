using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using Bolt.Compiler;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(BoltEventSend))]
    public class EventSendEditor : CustomActionEditor
    {
        BoltEventSend Action;
        Project proj = BPEditorUtils.OpenProject();
        string[] eventNames = BPEditorUtils.GetEventNames().ToArray();
        int index = 0;

        public override bool OnGUI()
        {
            Action = target as BoltEventSend; // identify the target action
            FsmBoltEvent guiItem = Action.EventId;
            guiItem.targetList = new string[3] {"test","test2","test3"};
            guiItem.selectionId = EditorGUILayout.Popup("Event", guiItem.selectionId, guiItem.targetList);

            return true;
        }

        public void UpdateVars()
        {/*
            List<PropertyDefinition> list = BPProjectHelper.GetEventProperties();

            for (int i = 0; i < list.Count; i++) // Loop with for.
            {
                switch (list[i].PropertyType)
            }
          * */
        }


    }
}