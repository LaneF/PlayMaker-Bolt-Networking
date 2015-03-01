/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Check if this user has control of the target entity.")]
	public class BoltEntityHasControl : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The GameObject in question.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Optionally store the result of the check.")]
		public FsmBool hasControl;

		[Tooltip("Optional True event.")]
		public FsmEvent doesHaveControl;

		[Tooltip("Optional False event.")]
		public FsmEvent doesNotHaveControl;

		public override void Reset()
		{
			gameObject = null;
			hasControl = false;
			doesHaveControl = null;
			doesNotHaveControl = null;
		}

		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go != null){

				var entity = go.GetComponent<BoltEntity>();
				bool b = entity.hasControl;
				hasControl.Value = b;

				Fsm.Event(b ? doesHaveControl : doesNotHaveControl);
				Finish ();
			}
		}
	}
}