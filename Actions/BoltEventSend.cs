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
        [UIHint(UIHint.Variable)]
        public int EventId = 0;

        [Tooltip("The Endpoint IPv4 Address.")]
        [UIHint(UIHint.Variable)]
        public FsmInt endPointIp;
        private UdpKit.UdpEndPoint _endPoint;

        public string test;

        public bool debugInfo;

        public override void Reset()
        {

        }

        public void OnAwake()
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