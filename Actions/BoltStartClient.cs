/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using Bolt;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Start a Bolt Client and connect to a Server.")]
	public class BoltStartClient : FsmStateAction
	{
        [Tooltip("Server IP address.")]
        public FsmString serverAddress;

        [Tooltip("Port number.")]
        public FsmString port;

        public override void Reset()
        {
            serverAddress = "127.0.0.1";
            port = "27000";
        }

		public override void OnEnter()
		{
            string addr = serverAddress.Value + ":" + port.Value;
            BoltLauncher.StartClient();
            BoltNetwork.Connect(UdpKit.UdpEndPoint.Parse(addr));
            Finish();
		}
	}
}