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
        Project proj = BPProjectHelper.OpenProject();
        string[] eventNames = BPProjectHelper.GetEventNames().ToArray();
        int index = 0;

        public void RevealBase()
        {
            EditField("index");
            EditField("test");
        }

        public override bool OnGUI()
        {
            Action = target as BoltEventSend; // identify the target action
            Action.EventId = EditorGUILayout.Popup(Action.EventId, eventNames);
            RevealBase();
            
            if (Action.EventId != index) // need to update the property variables!
            {
                index = Action.EventId;
                UpdateVars();
            }
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