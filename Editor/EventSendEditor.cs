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
    [CustomActionEditor(typeof(BoltEventSend))]
    public class EventSendEditor : CustomActionEditor
    {
        BoltEventSend Action;
        string[] eventNames = BPEditorUtils.GetEventNameList().ToArray();

        public override bool OnGUI()
        {
            Action = target as BoltEventSend; // identify the target action

            EventDefinition choiceEvent = BPEditorUtils.GetEventByIndex(Action.selectionId); // grab the chosen event

            Action.targetList = eventNames; // update the list
            Action.selectionId = EditorGUILayout.Popup("Event", Action.selectionId, Action.targetList); // update the gui in the editor

            EditField("propNames");
            EditField("propValues");

            #region old
            /*
              // clear the array entirely and resize the array
              Array.Clear(Action.vars, 0, Action.vars.Length);
              Array.Resize<FsmVar>(ref Action.vars, ListOfProperties.Count);

              // get the event type so we can access the properties
              Type Event = Type.GetType(Action.targetList[Action.selectionId]);

              // add the items to the array
              for (int i = 0; i < ListOfProperties.Count; i++)
              {
                  // find the property by name, using the dictionary of property names from the compiler.
                  FieldInfo field = Event.GetField(ListOfPropertyNames[i]);

                  Debug.Log("<color=yellow>i = " + i);
                  Debug.Log("eventChoiceId: " + eventChoiceId);
                  Debug.Log("selectionId  : " + Action.selectionId);
                  Debug.Log("PropList Count: " + ListOfProperties.Count);

                  // fill the variable
                  Action.vars[i].EnumType = field.GetValue(null).GetType();
                  Action.vars[i] = (FsmVar)field.GetValue(null);

                  // debug it
                  Debug.Log("<color=yellow>Prop Name: </color>" + ListOfPropertyNames[i]);
                  Debug.Log("<color=yellow>Value:     </color>" + Action.vars[i]);


              }

              // IsDirty
              eventChoiceId = Action.selectionId;

                
          }

          // each OnGUI, show the appropriate FsmVar popups
          for (int i = 0; i < propList.Count; i++)
          {
              Action.propVariables[i] = VariableEditor.FsmVarPopup(
                  new GUIContent(propNames[i]),
                  Action.Fsm,
                  Action.propVariables[i],
                  Action.propVariables[i].Type);
          }
          */
            #endregion

            return true; 

        }
    }
}