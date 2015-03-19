using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;


namespace BoltPlayMakerUtils
{
    /// <summary>
    /// This is a global event reciever for Network events, handled on each individual session.
    /// </summary>
    [BoltGlobalBehaviour] // this makes Bolt create an instance and maintain it. No need for a proxy object.
    public class CallbackGlobalProxy : Bolt.GlobalEventListener
    {
        FsmEventTarget target = new FsmEventTarget();
        FsmEventData data = new FsmEventData();
        GameObject proxyGo;
        PlayMakerFSM proxyFsm;

        void Start() { Setup(); }

        void Setup()
        {
            // proxyGo = new GameObject("Bolt Global Callback Proxy");
            // proxyGo.hideFlags = HideFlags.HideInHierarchy;
            // proxyGo.AddComponent<PlayMakerFSM>();
            gameObject.AddComponent<PlayMakerFSM>();
            proxyFsm = gameObject.GetComponent<PlayMakerFSM>();

            target.sendToChildren = true;
            target.target = FsmEventTarget.EventTarget.BroadcastAll;
        }

        #region Bolt Callbacks
        /// <summary>
        /// Callback triggered when the bolt simulation is shutting down.
        /// </summary>
        public override void BoltShutdown()
        {
            BoltConsole.Write("BPM Warning: Bolt Shutting Down...");
        }

        /// <summary>
        /// Callback triggered when the bolt simulation is starting.
        /// </summary>
        public override void BoltStarted()
        {
            // do some precalculation stuff with this...
            BoltConsole.Write("BPM Starting Game...");
        }

        public override void BoltStartFailed()
        {
            // (No API on this)...
            BoltConsole.Write("BPM Bolt Failed to Start...");
        }

        public override void BoltStartPending()
        {
            // (No API on this)...
            BoltConsole.Write("BPM BoltStartPending()");
        }
        #endregion

        #region Connection Callbacks
        /// <summary>
        /// Callback triggered when trying to connect to a remote endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        public override void ConnectAttempt(UdpKit.UdpEndPoint endpoint)
        {
            BoltConsole.Write("BPM ConnectAttempt");
        }

        public override void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken, Bolt.IProtocolToken connectToken)
        {
            if (proxyGo == null) { Setup(); }

            //data.StringData = (connection.RemoteEndPoint.Address + ":" + connection.RemoteEndPoint.Port);
            FsmEvent callback = new FsmEvent("BOLT / CONNECTED");
            // Fsm.EventData = data;
            proxyFsm.Fsm.Event(target, callback);

            BoltConsole.Write("BPM Connected");
            Debug.Log("BPM Invoked <color=red>Connected</color> Global Event.");
        }

        /// <summary>
        /// Callback triggered when a connection to remote server has failed
        /// </summary>
        /// <param name="endpoint"></param>
        public override void ConnectFailed(UdpKit.UdpEndPoint endpoint)
        {
            BoltConsole.Write("BPM Connect Failed");
        }

        /// <summary>
        /// Callback triggered when the connection to a remote server has been refused.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        public override void ConnectRefused(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Connect Refused");
        }

        /// <summary>
        /// Callback triggered when this instance receives an incoming client connection
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        public override void ConnectRequest(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Connect Request");
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
        #endregion

        #region Scene Callbacks
        /// <summary>
        /// Callback triggered when a remote connection has completely loaded the current scene
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="token"></param>
        public override void SceneLoadRemoteDone(BoltConnection connection, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM Scene Load Remote Done");
        }

        public override void SceneLoadLocalBegin(string scene, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM Scene Load Local Begin");
        }

        public override void SceneLoadLocalDone(string scene, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM Scene Load Local Done");
        }

        #endregion

        #region Entity Callbacks
        /// <summary>
        /// Callback triggered when this instance of bolt receieves control of a bolt entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void ControlOfEntityGained(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Control Of Entity Gained");
        }

        /// <summary>
        /// Callback triggered when this instance of bolt loses control of a bolt entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void ControlOfEntityLost(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Control Of Entity Lost");
        }

        /// <summary>
        /// Callback triggered when a new entity is attached to the bolt simulation
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void EntityAttached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            BoltConsole.Write("BPM Entity Attached");
        }

        /// <summary>
        /// Callback triggered when a new entity is detached from the bolt simulation
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        public override void EntityDetached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            // (No API on this)...
            BoltConsole.Write("BPM Entity Detached");
        }

        public override void EntityReceived(BoltEntity entity)
        {
            // (No API on this)...
            BoltConsole.Write("BPM Entity Received");
        }

        #endregion
    }
}