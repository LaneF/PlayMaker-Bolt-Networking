using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(BoltAddGlobalCallback))]
    public class CallbackEditor : CustomActionEditor
    {
        BoltAddGlobalCallback Action;

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
            Action = target as BoltAddGlobalCallback;

            switch (Action.callback)
            {
                case BoltAddGlobalCallback.CallbackType.Connected:
                    HasBoltConnection();
                    break;
                case BoltAddGlobalCallback.CallbackType.ConnectAttempt:
                    HasUdp();
                    break;
                case BoltAddGlobalCallback.CallbackType.ConnectFailed:
                    HasUdp();
                    break;
                case BoltAddGlobalCallback.CallbackType.ConnectRefused:
                    HasUdp();
                    break;
                case BoltAddGlobalCallback.CallbackType.ConnectRequest:
                    HasUdp();
                    break;
                case BoltAddGlobalCallback.CallbackType.Disconnected:
                    HasBoltConnection();
                    break;
                case BoltAddGlobalCallback.CallbackType.ControlOfEntityGained:
                    HasBoltEntity();
                    break;
                case BoltAddGlobalCallback.CallbackType.ControlOfEntityLost:
                    HasBoltEntity();
                    break;
                case BoltAddGlobalCallback.CallbackType.EntityAttached:
                    HasBoltEntity();
                    break;
                case BoltAddGlobalCallback.CallbackType.EntityDetached:
                    HasBoltEntity();
                    break;
                case BoltAddGlobalCallback.CallbackType.EntityReceived:
                    HasBoltEntity();
                    break;
                case BoltAddGlobalCallback.CallbackType.BoltShutdown:
                    // this callback has no arguments
                    break;
                case BoltAddGlobalCallback.CallbackType.BoltStarted:
                    // this callback has no arguments
                    break;
                case BoltAddGlobalCallback.CallbackType.BoltStartFailed:
                    // this callback has no arguments
                    break;
                case BoltAddGlobalCallback.CallbackType.BoltStartPending:
                    // this callback has no arguments
                    break;
                case BoltAddGlobalCallback.CallbackType.SceneLoadRemoteDone:
                    HasBoltConnection();
                    break;
                case BoltAddGlobalCallback.CallbackType.SceneLoadLocalBegin:
                    HasString();
                    break;
                case BoltAddGlobalCallback.CallbackType.SceneLoadLocalDone:
                    HasString();
                    break;
            }

            //return GUI.changed;
            return true;
        }
    }
}