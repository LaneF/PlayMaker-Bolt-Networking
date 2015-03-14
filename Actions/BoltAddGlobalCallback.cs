/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Open a callback for a specific target.")]
    public class BoltAddGlobalCallback : FsmStateAction
    {
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
       
        public CallbackType callback = CallbackType.Connected;

        [RequiredField]
        [Tooltip("Callback target.")]
        public FsmEventTarget callbackTarget;

        [Tooltip("Add an event here to wait in this state for the callback *and* remove the callback when we leave the state.")]
        public FsmEvent thisStateEvent;

        [Tooltip("The event name for the callback to send. *Ignored* if above field has an event.")]
        public FsmString eventName;

        [ActionSection("   Unique Options")]

        // TODO
        // Make Get Udp End Point Properties action.

        // HAS UdpEndPoint
        [Tooltip("The Endpoint IPv4 Address.")]
        [UIHint(UIHint.Variable)]
        public FsmInt endPointIp;
        private UdpKit.UdpEndPoint _endPoint;

        [Tooltip("The Endpoint Port Number.")]
        [UIHint(UIHint.Variable)]
        public FsmInt endPointPort;


        // HAS BoltEntity
        [Tooltip("The entity as a GameObject.")]
        [UIHint(UIHint.Variable)]
        public FsmGameObject entity;
        private BoltEntity _entity;


        // HAS BoltConnection
        [Tooltip("Store the Connection that this occured on.")]
        [UIHint(UIHint.Variable)]
        public FsmInt connectionId;


        // HAS String
        public FsmString text;

        public bool debugInfo;

        public override void Reset()
        {
            callback = CallbackType.Connected;
            callbackTarget = null;
            thisStateEvent = null;
            eventName = "";

            endPointIp = null;
            endPointPort = null;
            entity = null;
            connectionId = null;
            text = "";
        }

        public void OnAwake()
        {
            if (entity != null) // if there is an entity, get the data from it.
            { 
                _entity = Get.Entity(entity.Value); 
            }
        }

        public override void OnEnter()
        {
            Main();
        }

        public void Main()
        {

        }
    }
}