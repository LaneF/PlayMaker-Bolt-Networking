/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using System;
using System.Collections.Generic;
using BoltPlayMakerUtils;
using Bolt;
using UdpKit;

namespace HutongGames.PlayMaker.Actions
{
    // INCOMPLETE!!!
	[ActionCategory("Bolt Networking")]
	[Tooltip("Get properties of a Connection")]
	public class BoltGetConnectionProperties : FsmStateAction
	{
        [ActionSection("   Connection Reference")]

		[Tooltip("The Connection reference. This is basically some Client.")]
		[UIHint(UIHint.Variable)]
		public FsmInt connectionId;

        public FsmBool everyFrame;

        [ActionSection("   Property References")]

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt BitsPerSecondIn;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt BitsPerSeconOut;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt ConnectionId;
        // public uint ConnectionId; // Does uint convert to int okay?

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt DejitterFrames;

        // TODO Make this its own action.. doesn't fundamentally belong here..
        // public EntityList HasControlOf;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmBool IsLoadingMap;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmFloat PingAliased;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmFloat PingNetwork;

        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmInt RemoteFrame;

        [ObjectType(typeof(UnityEngine.Object))] 
        [Tooltip("")]
        [UIHint(UIHint.Variable)]
        public FsmObject UserData; // I have no clue if this will work or not..

        private BoltConnection cn;
        List<BoltConnection> cList = new List<BoltConnection>();
        List<int> iList = new List<int>();

        public override void Reset()
        {
            connectionId = null;
            everyFrame = false;
 
            BitsPerSecondIn = null;
            BitsPerSeconOut = null;
            ConnectionId = null;
            DejitterFrames = null;
            IsLoadingMap = null;
            PingAliased = null;
            PingNetwork = null;
            RemoteFrame = null;
            UserData = null;
        }

		public override void OnEnter()
		{
            foreach(var cn in BoltNetwork.connections)
            {
                cList.Add(cn);
                //iList.Add(cn.ConnectionId as int);
            }

            Main();

            if (!everyFrame.Value)
            {
                Finish();
            }
		}

        public override void OnUpdate()
        {
            Main();
        }

        public void Main()
        {

            if (BitsPerSecondIn != null)
            {
                
            }
            
            if (BitsPerSeconOut != null)
            {

            }
            
            if (ConnectionId != null)
            {

            }

            if (DejitterFrames != null)
            {

            }

            if (IsLoadingMap != null)
            {

            }

            if (PingAliased != null)
            {

            }

            if (PingNetwork != null)
            {

            }

            if (RemoteFrame != null)
            {

            }

            if (UserData != null)
            {

            }
        }
	}
}

