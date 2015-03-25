/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Get the number of clients connected to this server.")]
	public class BoltServerGetClientCount : FsmStateAction
	{
		[Tooltip("The number of clients connected to this server.")]
		[UIHint(UIHint.Variable)]
		public FsmInt clientCount;

#pragma warning disable 0168

        public override void OnEnter()
        {

            foreach (var x in BoltNetwork.clients) 
            {
                clientCount.Value = +1;
            }


            Finish ();
        }

#pragma warning restore 0168

    }
}

