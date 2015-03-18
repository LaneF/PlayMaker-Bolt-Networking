using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(BoltGlobalCallbackAdd))]
    public class CallbackEditor : CustomActionEditor
    {
        BoltGlobalCallbackAdd Action;

        public void RevealBase()
        {
            EditField("callback");
            EditField("callBackTarget");
            EditField("thisStateEvent");
            EditField("eventName");
        }

        public void HasUdp(){
            RevealBase();
            EditField("endPointIp");
            EditField("endPointPort");
        }

        public void HasBoltConnection(){
            RevealBase();
            EditField("connectionId");
        }

        public void HasBoltEntity(){
            RevealBase();
            EditField("entity");
        }

        public void HasString(){
            RevealBase();
            EditField("text");
        }

        public override bool OnGUI()
        {
            Action = target as BoltGlobalCallbackAdd;

            switch (Action.callback)
            {
                case BoltGlobalCallbackAdd.CallbackType.Connected:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ConnectAttempt:
                    HasUdp();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ConnectFailed:
                    HasUdp();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ConnectRefused:
                    HasUdp();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ConnectRequest:
                    HasUdp();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.Disconnected:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ControlOfEntityGained:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.ControlOfEntityLost:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.EntityAttached:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.EntityDetached:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.EntityReceived:
                    HasBoltEntity();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.BoltShutdown:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackAdd.CallbackType.BoltStarted:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackAdd.CallbackType.BoltStartFailed:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackAdd.CallbackType.BoltStartPending:
                    RevealBase(); // this callback has no arguments
                    break;
                case BoltGlobalCallbackAdd.CallbackType.SceneLoadRemoteDone:
                    HasBoltConnection();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.SceneLoadLocalBegin:
                    HasString();
                    break;
                case BoltGlobalCallbackAdd.CallbackType.SceneLoadLocalDone:
                    HasString();
                    break;
            }
            return true;
        }
    }
}