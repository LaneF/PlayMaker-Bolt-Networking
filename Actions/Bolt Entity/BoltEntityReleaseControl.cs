/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Release control of a Bolt Entity.")]
	public class BoltEntityReleaseControl : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The target GameObject.")]
		public FsmOwnerDefault gameObject;

		public override void Reset()
		{
			gameObject = null;
		}

		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			if (go != null)
			{
				Get.Entity(go).ReleaseControl();
			}

			Finish ();
		}
	}
}