using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;

/// <summary>
/// A generic Callback component.
/// </summary>
public class BPCallback : Bolt.EntityBehaviour<IState> 
{
    public string propertyName;
    public PlayMakerFSM returnTarget;
    public string callEvent;

// TODO update loop should see if the FSM exists and RemoveCallback() if not.
	public void Setup(string property, PlayMakerFSM target, string anEvent)
    {
        propertyName = property;
        returnTarget = target;
        callEvent = anEvent;

        Debug.Log("Setup this Callback!");
        state.AddCallback(propertyName, DoCallback);
	}

    public void Update()
    {
        if (returnTarget == null) { RemoveCallback(); } // callback should die if it has no target
    }

    public void DoCallback()
    {
        Debug.Log("Did a callback!");
        returnTarget.SendEvent(callEvent);
    }

    public void RemoveCallback()
    {
        Destroy(this);
    }
    
    void OnDestroy()
    {
        Debug.LogWarning("Removed a Callback!");
        state.RemoveCallback(propertyName, DoCallback);
    }
}