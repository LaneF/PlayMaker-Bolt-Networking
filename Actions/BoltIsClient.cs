/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Check if this user is a client.")]
	public class BoltIsClient : FsmStateAction
	{
		[Tooltip("Bolt's return on the isClient test.")]
		[UIHint(UIHint.Variable)]
		public FsmBool result;

		[Tooltip("Optional event.")]
		public FsmEvent isClient;

		[Tooltip("Optional event.")]
		public FsmEvent isNotClient;

		public override void OnEnter()
		{
			bool b = BoltNetwork.isClient;
			result.Value = b;

			Fsm.Event(b ? isClient : isNotClient);
			Finish ();
		}
	}
}

