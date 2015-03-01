/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Get the Prefab Id of a Bolt GameObject.")]
	public class BoltEntityTakeControl : FsmStateAction
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
				var entity = go.GetComponent<BoltEntity>();
				entity.TakeControl();
			}

			Finish ();
		}
	}
}