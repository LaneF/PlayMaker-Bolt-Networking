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
    public class CallbackConnections : Bolt.GlobalEventListener
    {
        public PlayMakerFSM targetFsm;
        public string callEvent;
        public FsmEventData eventData;

        public void Setup(PlayMakerFSM target, string anEvent)
        {
            targetFsm = target;
            callEvent = anEvent;
        }

        public void Update()
        {
            if (targetFsm == null) { RemoveCallback(); } // callback should die if it has no target
        }

        public void RemoveCallback()
        {
            Destroy(this);
        }

        void OnDestroy()
        {
        }

        /// <summary>
        /// Callback triggered when the bolt simulation is shutting down.
        /// </summary>
        public override void BoltShutdown()
        {
            PlayMakerUtils.SendEventToGameObject(targetFsm, targetFsm.gameObject, callEvent, null);

            targetFsm.SendEvent(callEvent);
            // alert that the server has collapsed...
            BoltConsole.Write("BPM Warning: Server Shutting Down...");
        }

        /// <summary>
        /// Callback triggered when the bolt simulation is starting.
        /// </summary>
        public override void BoltStarted()
        {
            targetFsm.SendEvent(callEvent);
            // do some precalculation stuff with this...
            BoltConsole.Write("BPM Starting Game...");
        }

        public override void BoltStartFailed()
        {
            targetFsm.SendEvent(callEvent);
            // (No API on this)...
            BoltConsole.Write("BPM Bolt Failed to Start...");
        }

        public override void BoltStartPending()
        {
            targetFsm.SendEvent(callEvent);
            // (No API on this)...
            BoltConsole.Write("BPM BoltStartPending()");
        }

        /// <summary>
        /// Callback triggered when trying to connect to a remote endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        public override void ConnectAttempt(UdpKit.UdpEndPoint endpoint)
        {
            targetFsm.SendEvent(callEvent);
            BoltConsole.Write("BPM ConnectAttempt");
        }

        public override void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken, Bolt.IProtocolToken connectToken)
        {
            targetFsm.SendEvent(callEvent);
            // (No API on this)...
            BoltConsole.Write("BPM Connected");
        }

        /// <summary>
        /// Callback triggered when a connection to remote server has failed
        /// </summary>
        /// <param name="endpoint"></param>
        public override void ConnectFailed(UdpKit.UdpEndPoint endpoint)
        {
            targetFsm.SendEvent(callEvent);
            BoltConsole.Write("BPM ConnectFailed");
        }

        /// <summary>
        /// Callback triggered when the connection to a remote server has been refused.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        public override void ConnectRefused(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            targetFsm.SendEvent(callEvent);
            BoltConsole.Write("BPM ConnectRefused");
        }

        /// <summary>
        /// Callback triggered when this instance receives an incoming client connection
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        public override void ConnectRequest(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            targetFsm.SendEvent(callEvent);
            BoltConsole.Write("BPM ConnectRequest");
        }

        /// <summary>
        /// Callback triggered when disconnected from remote server
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="token"></param>
        public override void Disconnected(BoltConnection connection, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Disconnected");
        }

        /// <summary>
        /// Callback triggered when a remote connection has completely loaded the current scene
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="token"></param>
        public override void SceneLoadRemoteDone(BoltConnection connection, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM SceneLoadRemoteDone");
        }

        /// <summary>
        /// Callback triggered when this instance of bolt receieves control of a bolt entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void ControlOfEntityGained(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM ControlOfEntityGained");
        }

        /// <summary>
        /// Callback triggered when this instance of bolt loses control of a bolt entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void ControlOfEntityLost(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM ControlOfEntityLost");
        }

        /// <summary>
        /// Callback triggered when a new entity is attached to the bolt simulation
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void EntityAttached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM EntityAttached");
        }

        /// <summary>
        /// Callback triggered when a new entity is detached from the bolt simulation
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void EntityDetached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM EntityDetached");
        }

        public override void EntityReceived(BoltEntity entity)
        {
            // (No API on this)...
            BoltConsole.Write("BPM EntityReceived");
        }

        public override void SceneLoadLocalBegin(string scene, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM SceneLoadLocalBegin");
        }

        public override void SceneLoadLocalDone(string scene, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM SceneLoadLocalDone");
        }


    }
}