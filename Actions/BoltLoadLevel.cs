/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;
using Bolt;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Load a Level through Bolt, all clients will comply.")]
	public class BoltLoadLevel : FsmStateAction
	{
        [RequiredField]
        [Tooltip("The name of the scene. Make sure it is in the build list.")]
        public FsmString levelName;

        public override void Reset()
        {
            levelName = "";
        }

		public override void OnEnter()
		{
            BoltNetwork.LoadScene(levelName.Value);
		}
	}
}