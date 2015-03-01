/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

// TODO Option to store the GameObject that the PrefabId points to.

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Get the Prefab Id of a Bolt GameObject.")]
	public class BoltEntityGetPrefabId : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The target GameObject.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt prefabId;

		public override void Reset()
		{
			gameObject = null;
			prefabId = null;
		}

		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			if (go != null)
			{
				var entity = go.GetComponent<BoltEntity>().prefabId.Value;
				prefabId.Value = entity;
			}

			Finish ();
		}
	}
}