/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{

    // INCOMPLETE...ish
    [ActionCategory("Bolt Networking")]
    [Tooltip("Open a callback for a specific target.")]
    public class BoltGlobalCallbackGetData : FsmStateAction
    {
        #region init
        public enum CallbackType
        {
            Connected,          // BoltConnection
            ConnectAttempt,     // UdpEndPoint
            ConnectFailed,      // UdpEndPoint
            ConnectRefused,     // UdpEndPoint
            ConnectRequest,     // UdpEndPoint
            Disconnected,       // BoltConnection

            ControlOfEntityGained,  // BoltEntity
            ControlOfEntityLost,    // BoltEntity
            EntityAttached,         // BoltEntity
            EntityDetached,         // BoltEntity
            EntityReceived,         // BoltEntity

            BoltShutdown,       // none
            BoltStarted,        // none
            BoltStartFailed,    // none
            BoltStartPending,   // none

            SceneLoadRemoteDone,    // BoltConnection
            SceneLoadLocalBegin,    // string
            SceneLoadLocalDone,     // string
        }
       
        [Title("Global Callback Type:")]
        public CallbackType callback = CallbackType.Connected;

        // TODO
        // Make Get Udp End Point Properties action.

        // HAS UdpEndPoint
        [ActionSection("  Options:")]
        [Tooltip("The Endpoint IPv4 Address.")]
        [UIHint(UIHint.Variable)]
        public FsmString endPointAddress;

        [Tooltip("The Endpoint Port Number.")]
        [UIHint(UIHint.Variable)]
        public FsmInt endPointPort;

        // HAS BoltEntity
        [ActionSection("  Options:")]
        [Tooltip("The Entity as a GameObject.")]
        [UIHint(UIHint.Variable)]
        public FsmGameObject entity;

        [Tooltip("Do we have control of this Entity?")]
        [UIHint(UIHint.Variable)]
        public FsmBool hasControl;

        [Tooltip("Do we have control of this Entity(with prediction)?")]
        [UIHint(UIHint.Variable)]
        public FsmBool hasControlWithPrediction;

        // HAS BoltConnection
        [ActionSection("  Options:")]
        [Tooltip("Store the Connection that this occured on.")]
        [UIHint(UIHint.Variable)]
        public FsmString connectionId;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt bitsPerSecondIn;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt bitsPerSecondOut;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt dejitterFrames;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmBool isLoadingMap;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmFloat pingAliased;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmFloat pingNetwork;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmString address;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt port;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt remoteFrame;

        // HAS String
        [ActionSection("  Options:")]
        [UIHint(UIHint.Variable)]
        public FsmString scene;
        #endregion

        public override void Reset()
        {
            callback = CallbackType.Connected;

            endPointAddress = null;
            endPointPort = null;
            entity = null;
            hasControl = null;
            hasControlWithPrediction = null;
            connectionId = null;
            bitsPerSecondIn = null;
            bitsPerSecondOut = null;
            dejitterFrames = null;
            isLoadingMap = null;
            pingAliased = null;
            pingNetwork = null;
            address = null;
            port = null;
            remoteFrame = null;
            scene = null;
        }

        public override void OnEnter()
        {
            #region endpoint data
            if (!endPointAddress.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("EndPointAddress", out foo);
                endPointAddress.Value = (string)foo;
            }

            if (!endPointPort.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("EndPointPort", out foo);
                endPointPort.Value = (int)foo;
            }
            #endregion

            #region entity data
            if (!entity.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("EntityGameObject", out foo);
                entity.Value = (GameObject)foo;
            }

            if (!hasControl.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("HasControl", out foo);
                hasControl.Value = Convert.ToBoolean(foo);
            }

            if (!hasControlWithPrediction.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("HasControlWithPrediction", out foo);
                hasControlWithPrediction.Value = Convert.ToBoolean(foo);
            }
            #endregion

            #region connection data
            if (!bitsPerSecondIn.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("BitsPerSecondIn", out foo);
                bitsPerSecondIn.Value = Convert.ToInt32(foo);
            }

            if (!bitsPerSecondOut.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("BitsPerSecondOut", out foo);
                bitsPerSecondOut.Value = Convert.ToInt32(foo);
            }

            if (!connectionId.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("ConnectionId", out foo);
                connectionId.Value = Convert.ToString(foo);
            }

            if (!dejitterFrames.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("DeJitterFrames", out foo);
                dejitterFrames.Value = Convert.ToInt32(foo);
            }

            if (!isLoadingMap.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("IsLoadingMap", out foo);
                isLoadingMap.Value = Convert.ToBoolean(foo);
            }

            if (!pingAliased.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("PingAliased", out foo);
                pingAliased.Value = Convert.ToInt32(foo);
            }

            if (!pingNetwork.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("PingNetwork", out foo);
                pingNetwork.Value = Convert.ToInt32(foo);
            }

            if (!address.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("Address", out foo);
                address.Value = Convert.ToString(foo);
            }

            if (!port.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("Port", out foo);
                port.Value = Convert.ToInt32(foo);
            }

            if (!remoteFrame.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("RemoteFrame", out foo);
                remoteFrame.Value = Convert.ToInt32(foo);
            }
            #endregion

            if (!scene.IsNone)
            {
                object foo;
                CallbackGlobalProxy.GlobalCallbackEventData.TryGetValue("Scene", out foo);
                scene.Value = Convert.ToString(foo);
            }
        }
    }
}