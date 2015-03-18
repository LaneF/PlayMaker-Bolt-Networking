/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Get a Rect Property from a Bolt Entity.")]
	public class BoltStateGetRect : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The GameObject with the property.")]
		public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("The name of the Property.")]
        public FsmString propertyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("The Variable to store the returned Property in.")]
        public FsmRect storeResult;

        [Tooltip("Do this every frame?")]
        public bool everyFrame;

        private GameObject _go;

		public override void Reset()
		{
            gameObject = null;
            propertyName = "SomeColor";
            storeResult = null;
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

            storeResult.Value = (Rect)Get.Property(_go, propertyName.Value);
        }
	}
}

