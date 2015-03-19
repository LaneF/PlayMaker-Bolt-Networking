using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;

/// <summary>
/// Bolt Entity Playmaker proxy.
/// Each Bolt Entity requires one of these. It will handle OnAttached(), general setup and 
/// fire events or code that need to take place here or is better than being duplicated in actions.
/// </summary>
public class BoltEntityPlaymakerProxy : Bolt.EntityBehaviour<IState> 
{
    [BPTooltip("Use SetTransforms() on this entity? This is for Syncing the position across the network by linking it to a Transform state property.")]
    public bool setTransforms = true;

    [BPTooltip("The name of the Transform property you want this entity to sync with.")]
    public string transformName = "Transform";

    [BPTooltip("OnAttached() is the first thing that happens when this Entity is attached on the Bolt Network. Here you can send an event to an FSM on this GameObject when Bolt calls OnAttached() for this Entity. Keep this string empty if you don't want to send any event.")]
    public string onAttachedFsmEvent = "";

    [BPTooltip("Type the FSM name (on this GameObject) that you want to send the event to.")]
    public string onAttachedFsmName = "FSM";

	/// <summary>
	/// Attached this instance.
	/// Attached() is fired when an Entity is connected on the Network.. Start() for network.
	/// </summary>
	public override void Attached()
    {
		if (setTransforms){
			((NetworkTransform)state.GetDynamic(transformName)).SetTransforms(gameObject.transform);
		}

        if (onAttachedFsmEvent != "")
        {
            Get.FsmByName(gameObject, onAttachedFsmName).SendEvent(onAttachedFsmEvent);
        }
	}
}