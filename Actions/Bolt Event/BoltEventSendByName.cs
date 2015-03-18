// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;
using Bolt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Sets Event Data before sending an event. Get the Event Data, Get Event Properties action.")]
	public class BoltEventSendByName : FsmStateAction
	{
        public FsmString eventName;

        [CompoundArray("Event Properties", "Name", "Value")]
        public FsmString[] propNames;
        public FsmVar[] propValues;

		public override void Reset()
		{
            eventName = "";
            propNames = new FsmString[1];
			propValues = new FsmVar[1];
		}
        
		public override void OnEnter()
		{
            object[] _vals = new object[propValues.Length];

            Type EventClass = Type.GetType(eventName.Value);
            ConstructorInfo eventConstructor = EventClass.GetConstructor(Type.EmptyTypes);
            object EventObject = eventConstructor.Invoke(new object[] { });

            // create the event
            MethodInfo Event_Create = EventClass.GetMethod("Create");
            Event_Create.Invoke(EventObject, null);

            // loop through the modified properties
            for (int i = 0; i < propValues.Length; i++)
            {
                // turn the FsmVar into an object
                _vals[i] = PlayMakerUtils.GetValueFromFsmVar(this.Fsm, propValues[i]);

                // create a reference to the property
                FieldInfo propField = EventClass.GetField(propNames[i].Value, BindingFlags.NonPublic | BindingFlags.Instance);

                // give the new object to the reference
                propField.SetValue(propField, _vals[i]);
            }

            // send the event
            MethodInfo Event_Send = EventClass.GetMethod("Send");
            Event_Send.Invoke(EventClass, null);

			Finish();
		}
	}
}