/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
    [Tooltip("Instantiate a Bolt Prefab. NOTE: Remember to assign the State and Compile Bolt!")]
	public class BoltInstantiate : FsmStateAction
	{
		[Tooltip("Choose a Prefab from the Project Hierarchy.\n" +
            "NOTE: Remember to assign the State and Compile Bolt!")]
		public FsmGameObject prefab;

		// TODO Add option for instantiation by PrefabId.

		[Tooltip("Optional Spawn Point.")]
		public FsmGameObject spawnPoint;
		
		[Tooltip("Position. If a Spawn Point is defined, this is used as a local offset from the Spawn Point position.")]
		public FsmVector3 position;
		
		[Tooltip("Rotation. NOTE: Overrides the rotation of the Spawn Point.")]
		public FsmVector3 rotation;

		[Tooltip("The source of the instantiation will take control of the entity. \n" +
			"Otherwise, no specific connection will have control of the GameObject.")]
		public FsmBool takeControl;

		[Tooltip("SetTransforms is Bolt's way to syncing the Transform of an object across the network.\n" +
			"If this instance needs to be synced, then this bool should be true.")]
		public FsmBool setTransforms;

		[Tooltip("The Transform property name in the State of the target entity.")]
		public FsmString transformPropertyName;

		[Tooltip("Send an event when finished.")]
		public FsmEvent finishEvent;

		[Tooltip("Send an event when finished.")]
		[UIHint(UIHint.Variable)]
		public FsmGameObject storeGameObject;

		public override void Reset()
		{
			prefab = null;
			spawnPoint = null;
			position = new FsmVector3 { UseVariable = true };
			rotation = new FsmVector3 { UseVariable = true };

			takeControl = true;
			transformPropertyName = "Transform";
			setTransforms = true;
			finishEvent = null;
			storeGameObject = null;
		}

		public override void OnEnter()
		{
			GameObject go = prefab.Value;
            Debug.Log("INSTANTIATING GAMEOBJECT: " + go);

            if (go != null)
            {
                #region Transform figuring...
                var spawnPosition = Vector3.zero;
				var spawnRotation = Vector3.zero;
				
				if (spawnPoint.Value != null)
				{
					spawnPosition = spawnPoint.Value.transform.position;
					
					if (!position.IsNone)
					{
						spawnPosition += position.Value;
					}

					spawnRotation = !rotation.IsNone ? rotation.Value : spawnPoint.Value.transform.eulerAngles;
				}

				else
				{
					if (!position.IsNone)
					{
						spawnPosition = position.Value;
					}
					
					if (!rotation.IsNone)
					{
						spawnRotation = rotation.Value;
					}
                }
            #endregion

                BoltEntity entity = BoltNetwork.Instantiate(go, spawnPosition, Quaternion.Euler(spawnRotation));
				storeGameObject.Value = entity.gameObject;

				// No one has control of an entity until explicitly defined.
				if (takeControl.Value) 
				{ 
					entity.TakeControl();
				}

				// Invoke SetTransforms() when the entity is Attached()
				if (setTransforms.Value)
				{
                    BoltEntityPlaymakerProxy _b = entity.gameObject.GetComponent<BoltEntityPlaymakerProxy>();
					_b.transformName = transformPropertyName.Value;
					_b.setTransforms = true;
				}
			}

			if (finishEvent != null)
			{
				Fsm.Event(finishEvent);
			}

			Finish ();
		}
	}
}