using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker;
using HutongGames.PlayMakerEditor;

namespace BoltPlayMakerUtils
{
    public class BPMenus : MonoBehaviour
    {
        [MenuItem("PlayMaker/Addons/Bolt Networking/Create Global Callback Events &b")]
        static void SetupGlobalEvents()
        {
            Debug.Log("Setting up Bolt Networking global callback events in Playmaker...");

            #region Connection Callbacks
            FsmEvent Connected = new FsmEvent("BOLT / CONNECTED");
            FsmEvent ConnectAttempt = new FsmEvent("BOLT / CONNECT ATTEMPT");
            FsmEvent ConnectFailed = new FsmEvent("BOLT / CONNECT FAILED");
            FsmEvent ConnectRefused = new FsmEvent("BOLT / CONNECT REFUSED");
            FsmEvent ConnectRequest = new FsmEvent("BOLT / CONNECT REQUEST");
            FsmEvent Disconnected = new FsmEvent("BOLT / DISCONNECTED");
            Connected.IsGlobal = true;
            ConnectAttempt.IsGlobal = true;
            ConnectFailed.IsGlobal = true;
            ConnectRefused.IsGlobal = true;
            ConnectRequest.IsGlobal = true;
            Disconnected.IsGlobal = true;
            FsmEvent.AddFsmEvent(Connected);
            FsmEvent.AddFsmEvent(ConnectAttempt);
            FsmEvent.AddFsmEvent(ConnectFailed);
            FsmEvent.AddFsmEvent(ConnectRefused);
            FsmEvent.AddFsmEvent(ConnectRequest);
            #endregion

            #region Bolt Callbacks
            FsmEvent BoltShutdown = new FsmEvent("BOLT / BOLT SHUTDOWN");
            FsmEvent BoltStarted = new FsmEvent("BOLT / BOLT STARTED");
            FsmEvent BoltStartFailed = new FsmEvent("BOLT / BOLT START FAILED");
            FsmEvent BoltStartPending = new FsmEvent("BOLT / BOLT START PENDING");
            BoltShutdown.IsGlobal = true;
            BoltStarted.IsGlobal = true;
            BoltStartFailed.IsGlobal = true;
            BoltStartPending.IsGlobal = true;
            FsmEvent.AddFsmEvent(Disconnected);
            FsmEvent.AddFsmEvent(BoltShutdown);
            FsmEvent.AddFsmEvent(BoltStarted);
            FsmEvent.AddFsmEvent(BoltStartFailed);
            FsmEvent.AddFsmEvent(BoltStartPending);
            #endregion

            #region Scene Callbacks
            FsmEvent SceneLoadRemoteDone = new FsmEvent("BOLT / SCENE LOAD REMOTE DONE");
            FsmEvent SceneLoadLocalBegin = new FsmEvent("BOLT / SCENE LOAD LOCAL BEGIN");
            FsmEvent SceneLoadLocalDone = new FsmEvent("BOLT / SCENE LOAD LOCAL DONE");
            SceneLoadRemoteDone.IsGlobal = true;
            SceneLoadLocalBegin.IsGlobal = true;
            SceneLoadLocalDone.IsGlobal = true;
            FsmEvent.AddFsmEvent(SceneLoadRemoteDone);
            FsmEvent.AddFsmEvent(SceneLoadLocalBegin);
            FsmEvent.AddFsmEvent(SceneLoadLocalDone);
            #endregion

            #region Entity Callbacks
            FsmEvent ControlOfEntityGained = new FsmEvent("BOLT / CONTROL OF ENTITY GAINED");
            FsmEvent ControlOfEntityLost = new FsmEvent("BOLT / CONTROL OF ENTITY LOST");
            FsmEvent EntityAttached = new FsmEvent("BOLT / ENTITY ATTACHED");
            FsmEvent EntityDetached = new FsmEvent("BOLT / ENTITY DETACHED");
            FsmEvent EntityReceived = new FsmEvent("BOLT / ENTITY RECEIVED");
            ControlOfEntityGained.IsGlobal = true;
            ControlOfEntityLost.IsGlobal = true;
            EntityAttached.IsGlobal = true;
            EntityDetached.IsGlobal = true;
            EntityReceived.IsGlobal = true;
            FsmEvent.AddFsmEvent(ControlOfEntityGained);
            FsmEvent.AddFsmEvent(ControlOfEntityLost);
            FsmEvent.AddFsmEvent(EntityAttached);
            FsmEvent.AddFsmEvent(EntityDetached);
            FsmEvent.AddFsmEvent(EntityReceived);
            #endregion

            Debug.Log("Finished setting up callback events!");

        }
    }
}