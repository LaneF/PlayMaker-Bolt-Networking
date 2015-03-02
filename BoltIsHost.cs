// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

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

