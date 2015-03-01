// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using Bolt;
using BoltInternal;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Sync a property on the network.")]
	public class BoltGetProperty : FsmStateAction
	{
		[RequiredField]
		public FsmOwnerDefault gameObject;

		public enum PropertyType
		{
			Array,
			Bool,
			Color,
			Entity,
			Float,
			Integer,
			NetworkId,
			Object,
			PrefabId,
			ProtocolToken,
			Quaternion,
			String,
			Transform,
			Trigger,
			Vector
		}

		public FsmBool isClient;
		[Tooltip("Optional event.")]
		public FsmEvent finished;

		public override void Reset()
		{
		}

//		public override void OnEnter()
//		{
//			go = Fsm.GetOwnerDefaultTarget(gameObject);
//			BoltEntity entity = go.GetComponent<BoltEntity>;
//			PrefabId id = entity.prefabId;
//
//			PrefabId id = go.GetComponent<BoltEntity>(PropertyCallback
//
//
//			Bolt.PrefabDatabase.Find (id)
//			state.GetDynamic
//			var property = Bolt.EntityBehaviour<
//
//			entity.TakeControl();
//		}
	}
}

