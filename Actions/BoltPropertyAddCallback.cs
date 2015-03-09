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
        [ActionSection("//Target Options//")]

        [RequiredField]
        [Tooltip("The GameObject with the property.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Where to send the event.")]
        public PlayMakerFSM target;

        [RequiredField]
        [Tooltip("The name of the Property.")]
        public FsmString propertyName;

        [ActionSection("//Event Options//")]

        [Tooltip("Event to send when the property changes. Highly recommend using a Global Event for this.")]
        public FsmEvent changedEvent;

        [Tooltip("Option to never finish this action. Possibly useful if not using Global Events for the callback.")]
        public FsmBool neverFinishState;


        private GameObject _go;

        public override void Reset()
        {
            gameObject = null;
            target = null;
            changedEvent = null;
            propertyName = "SomeProperty";
            neverFinishState = false;
        }

        public override void OnEnter()
        {
            _go = Fsm.GetOwnerDefaultTarget(gameObject);

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
            if (_go == null)
            {
                Debug.Log("GameObject is null!");
                return;
            }

            _go = Fsm.GetOwnerDefaultTarget(gameObject);

            CallbackEvent.Add(_go, propertyName.Value, target, changedEvent.Name);
            Debug.Log("Added a callback to " + _go + " on " + propertyName + ".");
        }
    }
}
