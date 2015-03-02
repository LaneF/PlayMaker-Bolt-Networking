using UnityEngine;
using Bolt;
using System.Collections;

/// <summary>
/// Bolt play maker proxy.
/// Intended to be a compilation of generic methods that you can fire from Playmaker Actions.
/// </summary>
public class BoltPlayMakerProxy : Bolt.EntityBehaviour<IState> {

	public bool doSetTransforms = true;
	public object propName;

	/// <summary>
	/// Attached this instance.
	/// Attached() is used for when an Entity is attached by Bolt to the Network.... ie, Start() for network.
	/// </summary>
	public override void Attached() {
		if (doSetTransforms){
			((NetworkTransform)state.GetDynamic("Transform")).SetTransforms(gameObject.transform);
		}
	}
}