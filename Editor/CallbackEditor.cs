using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(BoltGlobalCallbackGetData))]
    public class CallbackEditor : CustomActionEditor
    {
        BoltGlobalCallbackGetData Action;

        public void RevealBase()
        {
            EditField("callback");
        }

        public void HasEndPoint(){
            RevealBase();
            EditField("endPointAddress");
            EditField("endPointPort");
        }

        public void HasBoltConnection(){
            RevealBase();
            EditField("connectionId");
            EditField("bitsPerSecondIn");
            EditField("bitsPerSecondOut");
            EditField("dejitterFrames");
            EditField("isLoadingMap");
            EditField("pingAliased");
            EditField("pingNetwork");
            EditField("address");
            EditField("port");
            EditField("remoteFrame");
        }

        public void HasBoltEntity(){
            RevealBase();
            EditField("entity");
            EditField("hasControl");
            EditField("hasControlWithPrediction");
        }

        public void HasString(){
            RevealBase();
            EditField("scene");
        }

        public override bool OnGUI()
        {
            Action = target as BoltGlobalCallbackGetData;

            switch (Action.callback)
            {
                case BoltGlobalCallbackGetData.CallbackType.Connected:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ConnectAttempt:
                    HasEndPoint();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ConnectFailed:
                    HasEndPoint();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ConnectRefused:
                    HasEndPoint();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ConnectRequest:
                    HasEndPoint();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.Disconnected:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ControlOfEntityGained:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.ControlOfEntityLost:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.EntityAttached:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.EntityDetached:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.EntityReceived:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.BoltShutdown:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackGetData.CallbackType.BoltStarted:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackGetData.CallbackType.BoltStartFailed:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackGetData.CallbackType.BoltStartPending:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackGetData.CallbackType.SceneLoadRemoteDone:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.SceneLoadLocalBegin:
                    HasString();
                    break;
                case BoltGlobalCallbackGetData.CallbackType.SceneLoadLocalDone:
                    HasString();
                    break;
            }
            return true;
        }
    }
}