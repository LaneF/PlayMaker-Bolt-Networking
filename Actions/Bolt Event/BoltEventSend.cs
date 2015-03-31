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
    [ActionCategory("Bolt Networking")]
    [Tooltip("Send a Bolt Event on the Network.")]
    public class BoltEventSend : FsmStateAction
    {
        public string[] targetList;
        public int selectionId = 0;

        [CompoundArray("Event Properties", "Name", "Value")]
        [Tooltip("Invalid types or names will cause errors. Don't forget to compile Bolt.")]
        [Title("Propety Names")]
        public FsmString[] propNames;

        [Tooltip("Invalid types or names will cause errors. Don't forget to compile Bolt.")]
        [Title("Propety Values")]
        public FsmVar[] propValues;

        public override void Reset()
        {
            targetList = null;
            selectionId = 0;
            propNames = null;
            propValues = null;
        }

        public override void OnEnter()
        {
            CreateEvent();
        }
        
        public void CreateEvent()
        {
            // get the Bolt Event
            Type Event = Type.GetType(targetList[selectionId]);
            ConstructorInfo eventConstructor = Event.GetConstructor(Type.EmptyTypes);
            object EventObject = eventConstructor.Invoke(new object[]{});

            // fill the Bolt Event with the data
            MethodInfo Event_Create = Event.GetMethod("Create");
            Event_Create.Invoke(EventObject, null);

            for (int i = 0; i < propNames.Length; i++)
            {
                object value = PlayMakerUtils.GetValueFromFsmVar(Fsm, propValues[i]);
                FieldInfo field = Event.GetField(propNames[i].Value);
                field.SetValue(field, value);
            }

            // tell bolt to send the event
            MethodInfo Event_Send = Event.GetMethod("Send");
            Event_Send.Invoke(EventObject, null);

            // broadcast the custom event
            // CallbackGlobalProxy.BroadcastCustomEvent(Event.Name);
        }
    }
}