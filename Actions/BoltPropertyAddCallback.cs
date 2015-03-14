/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Fire an event on this FSM when a Property changes.")]
    public class BoltPropertyAddCallback : FsmStateAction
    {
        [ActionSection("   Property Options")]

        [RequiredField]
        [Tooltip("The GameObject with the Property you want a Callback on.")]
        public FsmOwnerDefault propertyHost;

        [RequiredField]
        [Tooltip("The name of the Property.")]
        public FsmString propertyName;

        [ActionSection("   Target Options")]

        [RequiredField]
        [Tooltip("The GameObject to send Callback events to.")]
        public FsmOwnerDefault targetGameObject;

        [RequiredField]
        [Tooltip("The FSM to send Callback events to.")]
        public FsmString targetFsmName;

        [ActionSection("   Event Options")]

        [RequiredField]
        [Tooltip("Event to send when the property changes. Highly recommend using a Global Event for this.")]
        public FsmString callbackEventName;

        public bool debugInfo;

        [Tooltip("Option to never finish this action. Rarely useful, but here just in case.")]
        public FsmBool neverFinishState;

        private GameObject _goHost;
        private GameObject _goTarget;

        public override void Reset()
        {
            propertyHost = null;
            propertyName = "SomeProperty";
            targetGameObject = null;
            targetFsmName = "FSM";
            callbackEventName = "";
            neverFinishState = false;
            debugInfo = false;
        }

        public override void OnEnter()
        {
            _goHost = Fsm.GetOwnerDefaultTarget(propertyHost);
            _goTarget = Fsm.GetOwnerDefaultTarget(targetGameObject);

            Main();

            if (!neverFinishState.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            // never finish the state.
        }

        public void Main()
        {
            if (_goHost == null)
            {
                Debug.LogWarning("The property host GameObject is null!");
                return;
            }

            // get the target fsm based on inputs
            PlayMakerFSM targetFsm = PlayMakerUtils.FindFsmOnGameObject(_goTarget, targetFsmName.Value);

            // hook the callback in
            Callback.Add(_goHost, propertyName.Value, targetFsm, callbackEventName.Value);

            if (debugInfo)
            {
                Debug.Log("Added a Callback to " + _goHost + " on " + propertyName + ". ");
                Debug.Log("Callback hooked to " + _goTarget + " in FSM '" + targetFsmName.Value + "', sending event '" + callbackEventName.Value + "'.");
            }
        }
    }
}
