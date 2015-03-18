/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using Bolt;
using System;
using System.Collections;
using System.Reflection;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Send a Bolt Event on the Network.")]
    public class BoltEventSend : FsmStateAction
    {
        public string[] targetList;

        public int selectionId = 0;

        [CompoundArray("Properties", "name", "fsm variable")]
        public string[] propNames;
        public FsmVar[] propVariables;

        private object[] _arguments;

        public override void OnEnter()
        {
            // TODO fill _arguments with current propVariables
            // or propVariables directly to the Invoke, but probably wont work.
            CreateEvent();
        }
        
        public void CreateEvent()
        {
            Type Event = Type.GetType(targetList[selectionId]);

            ConstructorInfo eventConstructor = Event.GetConstructor(Type.EmptyTypes);

            object EventObject = eventConstructor.Invoke(new object[]{});



            MethodInfo Event_Create = Event.GetMethod("Create");

            Event_Create.Invoke(EventObject, _arguments);
        }
    }
}