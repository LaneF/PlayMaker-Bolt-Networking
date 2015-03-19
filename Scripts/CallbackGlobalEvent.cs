using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;

namespace BoltPlaymaker
{
    /// <summary>
    /// This is a global event reciever for Network events, handled on each individual session.
    /// </summary>
    [BoltGlobalBehaviour]
    public class CallbackGlobalEvent : Bolt.GlobalEventListener
    {
        public string propertyName;
        public PlayMakerFSM returnTarget;
        public string callEvent;

        public void Setup(string property, PlayMakerFSM target, string anEvent)
        {
            propertyName = property;
            returnTarget = target;
            callEvent = anEvent;


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
            //state.RemoveCallback(propertyName, DoCallback);
        }
    }
}