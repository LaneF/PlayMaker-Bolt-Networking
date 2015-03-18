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
        string[] eventNames = BPEditorUtils.GetEventNameList().ToArray();
        int localIndex = 0;

        public override bool OnGUI()
        {
            Action = target as BoltEventSend; // identify the target action
            Action.targetList = eventNames; // update the list
            Action.selectionId = EditorGUILayout.Popup("Event", Action.selectionId, Action.targetList); // update the gui in the editor

            EventDefinition choiceEvent = BPEditorUtils.GetEventByIndex(localIndex); // grab the chosen event
            List<PropertyDefinition> propList = BPEditorUtils.GetEventPropertyList(choiceEvent); // grab the list of properties in that event
            List<string> propNames = BPEditorUtils.GetPropertyNameList(choiceEvent);

            if (localIndex != Action.selectionId) 
            {
                for (int i = 0; i < propList.Count; i++)
                {
                    Debug.Log("enter loop, i = " + i + " and propListCount = " + propList.Count);
                    Debug.Log("Action.propNames[i] = " + propNames[i]);
                    Debug.Log("Action.Fsm = " + Action.Fsm);
                    Debug.Log("Action.propVariables[i] = " + Action.propVariables[i]);

                    Action.propVariables[i] = VariableEditor.FsmVarPopup(new GUIContent(propNames[i]), Action.Fsm, Action.propVariables[i]);
                }

                localIndex = Action.selectionId;
                return true;
            }

            else
            {
                return false;
            }
            
        }
    }
}