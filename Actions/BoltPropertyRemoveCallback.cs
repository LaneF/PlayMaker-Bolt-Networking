/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Remove a Callback on a GameObject.")]
    public class BoltPropertyRemoveCallback : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The GameObject with the active Callback.")]
        public FsmOwnerDefault propertyHost;

        [RequiredField]
        [Tooltip("The name of the Property the Callback is operating on.")]
        public FsmString propertyName;

        private GameObject _goHost;

        public override void Reset()
        {
            propertyHost = null;
            propertyName = "SomeProperty";
        }

        public override void OnEnter()
        {
            _goHost = Fsm.GetOwnerDefaultTarget(propertyHost);

            Main();
        }

        public void Main()
        {
            if (_goHost == null)
            {
                Debug.LogWarning("The property host GameObject is null!");
                return;
            }

            CallbackEvent.Remove(_goHost, propertyName.Value);
        }
    }
}
