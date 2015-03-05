/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("SetTransforms for an entity.")]
	public class BoltEntitySetTransform : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The target GameObject.")]
		public FsmOwnerDefault gameObject;

		private BoltEntity entity;
		private GameObject go;

		public override void Reset()
		{
			gameObject = null;
		}

//		public override void OnEnter()
//		{
//			go = Fsm.GetOwnerDefaultTarget(gameObject);
//			
//			if (go != null)
//			{
//				entity = go.GetComponent<BoltEntity>();
//				entity.State.SetTransforms(transform);
//			}
//		}
	}
}