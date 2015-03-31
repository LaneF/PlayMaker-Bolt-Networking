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
        [CheckForComponent(typeof(BoltEntity))]
		public FsmGameObject prefab;

        //[Tooltip("Optionally spawn the Entity by Prefab Id. Use zero to ignore.")]
        //public FsmInt prefabId;

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
            // prefabId = 0;
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
			GameObject go = new GameObject();
            bool usingId = false;
            go = prefab.Value; 

            /*
            if (prefabId.Value == 0) // use the prefab slot if the prefab number is zero.
            {
                go = prefab.Value; 
            }

            else // if non-zero, get the prefab.
            {

                Bolt.PrefabId id = new Bolt.PrefabId();
                id.Value = prefabId.Value;

                go = Bolt.PrefabDatabase.Find(id);

                if (go != null)
                {
                    usingId = true;
                }

                else
                {
                    Debug.LogError("PrefabId returned no prefab! Check that the PrefabId exists and that Bolt is compiled.");
                }
            }
             * */

            if (go != null && !usingId)
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