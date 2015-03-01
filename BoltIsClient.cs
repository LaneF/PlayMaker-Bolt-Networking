// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Check if this is a client.")]
	public class BoltIsClient : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Bolt's return on the isClient test.")]
		[UIHint(UIHint.Variable)]
		public FsmBool isClient;
		[Tooltip("Optional event.")]
		public FsmEvent isAClient;
		[Tooltip("Optional event.")]
		public FsmEvent isNotAClient;

		public override void OnEnter()
		{
			isClient.Value = BoltNetwork.isClient;
			Fsm.Event(isClient.Value ? isAClient : isNotAClient);
			Finish ();
		}
	}
}

