/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using Bolt;
using System;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Bolt Networking")]
    [Tooltip("Send a Bolt Event on the Network.")]
    public class BoltEventSend : FsmStateAction
    {
        public FsmBoltEvent EventId;

        [CompoundArray("Properties", "name", "fsm variable")]
        public string[] properties;
        public FsmVar[] variables;

        public string test;

        public bool debugInfo;

        public override void Reset()
        {

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