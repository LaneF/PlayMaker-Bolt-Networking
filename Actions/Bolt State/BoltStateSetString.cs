/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Set a String Property on a Bolt Entity.")]
    public class BoltStateSetString : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The GameObject with the property.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("The name of the Property.")]
        public FsmString propertyName;

        [RequiredField]
        [Tooltip("The Variable to store the returned Property in.")]
        public FsmString setValue;

        [Tooltip("Do this every frame?")]
        public bool everyFrame;

        private GameObject _go;

        public override void Reset()
        {
            gameObject = null;
            propertyName = "SomeColor";
            setValue = null;
        }

        public override void OnEnter()
        {
            _go = Fsm.GetOwnerDefaultTarget(gameObject);

            Main();

            if (!everyFrame)
                Finish();
        }

        public override void OnUpdate()
        {
            Main();
        }

        public void Main()
        {
            if (_go == null)
            {
                _go = Fsm.GetOwnerDefaultTarget(gameObject);

                if (_go == null)
                {
                    Debug.Log("GameObject is null!");
                }
            }

            Set.Property(_go, propertyName.Value, setValue.Value);
        }
    }
}
