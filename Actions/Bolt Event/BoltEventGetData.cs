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
    [Tooltip("Get a custom Bolt Event's property values.")]
    public class BoltEventGetData : FsmStateAction
    {
        public string[] targetList;
        public int selectionId;

        [CompoundArray("Event Properties", "Property Name", "Store As")]
        public FsmString[] propNames;

        [UIHint(UIHint.Variable)]
        public FsmVar[] storeVariables;

        public override void Reset()
        {
            propNames = null;
            storeVariables = null;
        }

        public override void OnEnter()
        {
            Type Event = Type.GetType(targetList[selectionId]);

            for (int i = 0; i < propNames.Length; i++)
            {
                FieldInfo field = Event.GetField(propNames[i].Value);
                object pull = new object();
                field.GetValue(pull);

                PlayMakerUtils.ApplyValueToFsmVar(Fsm, storeVariables[i], pull);
            }
        }
    }
}