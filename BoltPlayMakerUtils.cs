using UnityEngine;
using Bolt;
using System;
using System.Collections;
using HutongGames.PlayMaker;

/// <summary>
/// Bolt play maker utilities.
/// Shorcuts for general commands.
/// </summary>
namespace BoltPlayMakerUtils
{
    public static class Get
    {
        /// <summary>
        /// Input GameObject, returns the BoltEntity on the GameObject.
        /// </summary>
        /// <param name="go">The target GameObject</param>
        /// <returns>A Bolt Entity</returns>
	    public static BoltEntity Entity(this GameObject go)
	    {
            return go.GetComponent<BoltEntity>();
	    }

        /// <summary>
        /// Input GameObject and Property name, get Property value back.
        /// </summary>
        /// <param name="go">GameObject Entity target</param>
        /// <param name="propertyName">Name of the Property</param>
        /// <returns>The Property from the Entity</returns>
        public static object Property(this GameObject go, string propertyName)
        {
            var property = Get.Entity(go).GetState<IState>().GetDynamic(propertyName);
            return property;
        }

        /// <summary>
        /// Input GameObject, get a state interface back.
        /// </summary>
        /// <param name="go">The target GameObject with the Entity and State</param>
        /// <returns>An interface state</returns>
        public static IState State(this GameObject go)
        {
            var state = Get.Entity(go).GetState<IState>();
            return state;
        }

        /// <summary>
        /// Get a named FSM on the target GameObject
        /// </summary>
        /// <param name="go">The GameObject with the FSM</param>
        /// <param name="fsmName">The name of the FSM</param>
        /// <returns>A PlayMakerFSM behavior</returns>
        public static PlayMakerFSM FsmByName(this GameObject go, string fsmName)
        {
            var fsm = go.GetComponents<PlayMakerFSM>();
            
            for (int i = 0; i < fsm.Length; i++)
            {
                if (fsm[i].FsmName == fsmName)
                {
                    return fsm[i];
                }
            }

            Debug.LogWarning("No FSM by name '" + fsmName + "' was found.");
            return null;
        }
	}

    public static class Set
    {
        /// <summary>
        /// Sets a Property on a Bolt Entity.
        /// </summary>
        /// <param name="go">Target GameObject</param>
        /// <param name="propertyName">Property Name</param>
        /// <param name="value">Value to set Property to</param>
        public static void Property(GameObject go, string propertyName, object value)
        {
            Get.Entity(go).GetState<IState>().SetDynamic(propertyName, value);
        }
    }


    public static class CallbackEvent
    {
        /// <summary>
        /// Used to find a Callback for a specific property on a GameObject.
        /// </summary>
        /// <param name="go"></param>
        /// <param name="propertyName"></param>
        /// <returns>If found, returns the BPCallback component</returns>
        public static BPCallback Find(this GameObject go, string propertyName)
        {
            BPCallback[] callbacks = go.GetComponents<BPCallback>();
            for (int i = 0; i < callbacks.Length; i++)
            {
                if (callbacks[i].propertyName == propertyName)
                {
                    return callbacks[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Used to Add a Callback that will fire an FSM Event when a property changes.
        /// </summary>
        /// <param name="go">The GameObject to add the Callback to</param>
        /// <param name="propertyName">The Property name the Callback operates on</param>
        /// <param name="returnFSM">The target FSM that the callback fires the event on</param>
        /// <param name="returnEventName">The named FSM Event to fire</param>
        public static void Add(this GameObject go, string propertyName, PlayMakerFSM returnTarget, string callEvent)
        {
            // I don't see a safe way to have multiple Callbacks fire different events on the same Entity and Property.
            if (CallbackEvent.Find(go, propertyName) == null)
            {
                var cb = go.AddComponent<BPCallback>();
                cb.propertyName = propertyName;
                cb.returnTarget = returnTarget;
                cb.callEvent = callEvent;

                cb.Setup(propertyName, returnTarget, callEvent); // the component adds its own callback in Setup().

            } else {
                Debug.LogWarning("Callback to property '" + propertyName + "' already exists on " + go + "!... Doing nothing."); 
            }
        }

        /// <summary>
        /// Used to Remove a Callback on a specific GameObject and Property.
        /// </summary>
        /// <param name="go">The Target GameObject with the Callback</param>
        /// <param name="propertyName">The name of the property the Callback is operating on</param>
        public static void Remove(this GameObject go, string propertyName)
        {
            BPCallback cb = CallbackEvent.Find(go, propertyName);
            if (cb == null)
            {
                Debug.LogWarning("Callback to property '" + propertyName + "' not found on " + go + "!"); 
                return;
            }

            else { cb.RemoveCallback(); }
        }
    }
}