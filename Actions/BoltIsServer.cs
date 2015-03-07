/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Check if this user is the Server.")]
	public class BoltIsServer : FsmStateAction
	{
		[Tooltip("Bolt's return on the isServer test.")]
		[UIHint(UIHint.Variable)]
		public FsmBool result;

		[Tooltip("Optional event.")]
		public FsmEvent isServer;

		[Tooltip("Optional event.")]
		public FsmEvent isNotServer;

		public override void OnEnter()
		{
			bool b = BoltNetwork.isServer;
			result.Value = b;

			Fsm.Event(b ? isServer : isNotServer);
			Finish ();
		}
	}
}