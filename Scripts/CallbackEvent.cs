using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;

namespace BoltPlayMakerUtils
{
    /// <summary>
    /// A generic Callback component.
    /// </summary>
    public class CallbackEvent : Bolt.EntityBehaviour<IState>
    {
        public string propertyName;
        public PlayMakerFSM returnTarget;
        public string callEvent;

        public void Setup(string property, PlayMakerFSM target, string anEvent)
        {
            propertyName = property;
            returnTarget = target;
            callEvent = anEvent;

            state.AddCallback(propertyName, DoCallback);
        }

        public void Update()
        {
            if (returnTarget == null) { RemoveCallback(); } // callback should die if it has no target
        }

        public void DoCallback()
        {
            returnTarget.SendEvent(callEvent);
        }

        public void RemoveCallback()
        {
            Destroy(this);
        }

        void OnDestroy()
        {
            if (BoltNetwork.isRunning)
            {
                state.RemoveCallback(propertyName, DoCallback);
            }
        }
    }
}