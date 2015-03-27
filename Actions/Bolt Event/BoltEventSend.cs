/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using Bolt;
using UdpKit;
using System;
using System.Collections;
using System.Reflection;

namespace HutongGames.PlayMaker.Actions
{
    // INCOMPLETE!!!
    [ActionCategory("Bolt Networking")]
    [Tooltip("Send a Bolt Event on the Network.")]
    public class BoltEventSend : FsmStateAction
    {
        public string[] targetList;
        public int selectionId = 0;

        [HideTypeFilter]
        [UIHint(UIHint.Variable)]
        public FsmVar[] vars;

        private object[] _arguments; // must be filled by editor script

        public override void OnEnter()
        {
            CreateEvent();
        }
        
        public void CreateEvent()
        {
            // use reflection to fire Event.Create and Event.Send
            Type Event = Type.GetType(targetList[selectionId]);
            ConstructorInfo eventConstructor = Event.GetConstructor(Type.EmptyTypes);
            object EventObject = eventConstructor.Invoke(new object[]{});

            MethodInfo Event_Create = Event.GetMethod("Create");
            Event_Create.Invoke(EventObject, null);
            

            // fill the event arguments here...



            MethodInfo Event_Send = Event.GetMethod("Send");
            Event_Send.Invoke(EventObject, null);
        }
    }
}