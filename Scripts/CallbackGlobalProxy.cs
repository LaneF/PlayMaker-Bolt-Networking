using UnityEngine;
using Bolt;
using BoltPlayMakerUtils;
using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;


namespace BoltPlayMakerUtils
{
    /// <summary>
    /// This is a global event reciever for Network events, handled on each individual session.
    /// </summary>
    [BoltGlobalBehaviour] // this creates an instance on Bolt and maintain it. No need for a proxy object.
    public class CallbackGlobalProxy : Bolt.GlobalEventListener
    {
        // WHEN ADDING CALLBACKS, MAKE SURE THEY ARE ALSO IN THE MENUS.CS FILE SO THAT THEY APPEAR AS AN EVENT FOR THE USER.

        FsmEventTarget _eventTarget = new FsmEventTarget();
        GameObject proxyGo;
        PlayMakerFSM proxyFsm;

        static public Dictionary<string, object> GlobalCallbackEventData = new Dictionary<string, object>();

        void Start() { Setup(); }
        void Setup()
        {
            Debug.Log("Proxy FSM for Global events was null, reinitiating Setup()...");

            proxyFsm = gameObject.GetComponent<PlayMakerFSM>();

            if (proxyFsm == null)
            {
                gameObject.AddComponent<PlayMakerFSM>();
                proxyFsm = gameObject.GetComponent<PlayMakerFSM>();
            }

            _eventTarget.target = FsmEventTarget.EventTarget.BroadcastAll;
            Debug.Log("***Finished Setup for the Bolt Callback Global Proxy***");
        }

        #region Dictionary Modifiers
        void PassDataOfConnection(BoltConnection connection)
        {
            GlobalCallbackEventData.Add("BitsPerSecondIn", connection.BitsPerSecondIn);
            GlobalCallbackEventData.Add("BitsPerSecondOut", connection.BitsPerSecondOut);
            GlobalCallbackEventData.Add("ConnectionId", connection.ConnectionId);
            GlobalCallbackEventData.Add("DeJitterFrames", connection.DejitterFrames);
            GlobalCallbackEventData.Add("IsLoadingMap", connection.IsLoadingMap);
            GlobalCallbackEventData.Add("PingAliased", connection.PingAliased);
            GlobalCallbackEventData.Add("PingNetwork", connection.PingNetwork);
            GlobalCallbackEventData.Add("Address", connection.RemoteEndPoint.Address.ToString());
            GlobalCallbackEventData.Add("Port", connection.RemoteEndPoint.Port);
            GlobalCallbackEventData.Add("RemoteFrame", connection.RemoteFrame);
        }

        void PassDataOfEndPoint(UdpKit.UdpEndPoint endpoint)
        {
            GlobalCallbackEventData.Add("EndPointAddress", endpoint.Address.ToString());
            GlobalCallbackEventData.Add("EndPointPort", endpoint.Port);
        }

        void PassDataOfEntity(BoltEntity entity)
        {
            GlobalCallbackEventData.Add("EntityGameObject", entity.gameObject);
            GlobalCallbackEventData.Add("HasControl", entity.hasControl);
            GlobalCallbackEventData.Add("HasControlWithPrediction", entity.hasControlWithPrediction);
        }
        #endregion

        #region Connection Callbacks
        public override void ConnectAttempt(UdpKit.UdpEndPoint endpoint)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEndPoint(endpoint);


            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONNECT ATTEMPT");
            BoltConsole.Write("BP Connect Attempt on " + endpoint.Address + ":" + endpoint.Port);
        }
        
        public override void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken, Bolt.IProtocolToken connectToken)
        {
            if (proxyFsm == null) 
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfConnection(connection);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONNECTED");
            BoltConsole.Write("BP Connected on " + connection.RemoteEndPoint.Address + ":" + connection.RemoteEndPoint.Port);
        }
        
        public override void ConnectFailed(UdpKit.UdpEndPoint endpoint)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEndPoint(endpoint);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONNECT FAILED");
            BoltConsole.Write("BP Connect Failed on " + endpoint.Address + ":" + endpoint.Port);
        }

        public override void ConnectRefused(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEndPoint(endpoint);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONNECT REFUSED");
            BoltConsole.Write("BP Connect Refused on " + endpoint.Address + ":" + endpoint.Port);
        }

        public override void ConnectRequest(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEndPoint(endpoint);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONNECT REQUEST");
            BoltConsole.Write("BPM Connect Request on " + endpoint.Address + ":" + endpoint.Port);
        }

        public override void Disconnected(BoltConnection connection, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfConnection(connection);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / DISCONNECTED");
            BoltConsole.Write("BP Disconnected on " + connection.RemoteEndPoint.Address + ":" + connection.RemoteEndPoint.Port);
        }
        #endregion

        #region Scene Callbacks
        public override void SceneLoadRemoteDone(BoltConnection connection, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfConnection(connection);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / SCENE LOAD REMOTE DONE");
            BoltConsole.Write("BP Scene Load Remote Done" + connection.RemoteEndPoint.Address + ":" + connection.RemoteEndPoint.Port);
        }

        public override void SceneLoadLocalBegin(string scene, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            GlobalCallbackEventData.Add("Scene", scene);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / SCENE LOAD LOCAL BEGIN");
            BoltConsole.Write("BP Scene Load Local Begin... Scene: " + scene);

        }

        public override void SceneLoadLocalDone(string scene, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            GlobalCallbackEventData.Add("Scene", scene);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / SCENE LOAD LOCAL DONE");
            BoltConsole.Write("BP Scene Load Local Done... Scene: " + scene);
        }

        #endregion

        #region Entity Callbacks
        public override void ControlOfEntityGained(BoltEntity entity, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEntity(entity);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONTROL OF ENTITY GAINED");
            BoltConsole.Write("BP Control Of Entity Gained: " + entity.name);
        }

        public override void ControlOfEntityLost(BoltEntity entity, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEntity(entity);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / CONTROL OF ENTITY LOST");
            BoltConsole.Write("BP Control Of Entity Lost: " + entity.name);
        }

        public override void EntityAttached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEntity(entity);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / ENTITY ATTACHED");
            BoltConsole.Write("BP Entity Attached: " + entity.name);
        }

        public override void EntityDetached(BoltEntity entity, Bolt.IProtocolToken token)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEntity(entity);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / ENTITY DETACHED");
            BoltConsole.Write("BP Entity Detached: " + entity.name);
        }

        public override void EntityReceived(BoltEntity entity)
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            GlobalCallbackEventData.Clear();
            PassDataOfEntity(entity);

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / ENTITY RECEIVED");
            BoltConsole.Write("BP Entity Received: " + entity.name);
        }

        #endregion        
        
        #region Bolt Callbacks
        public override void BoltShutdown()
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / BOLT SHUTDOWN");
            BoltConsole.Write("BP Bolt Shutdown");
        }

        public override void BoltStarted()
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / BOLT STARTED");
            BoltConsole.Write("BP Bolt Started");
        }

        public override void BoltStartFailed()
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / BOLT START FAILED");
            BoltConsole.Write("BP Bolt Start Failed");
        }

        public override void BoltStartPending()
        {
            if (proxyFsm == null)
            {
                Setup();
            }

            proxyFsm.Fsm.Event(_eventTarget, "BOLT / BOLT START PENDING");
            BoltConsole.Write("BP Bolt Start Pending");
        }
        #endregion

        public static void BroadcastCustomEvent(string name)
        {
            // proxyFsm.Fsm.Event(_eventTarget, name);
        }
    }
}