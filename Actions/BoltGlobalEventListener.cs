/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;
using BoltPlayMakerUtils;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Bolt Networking")]
	[Tooltip("Fire events from on Network Global Events.")]
	public class BoltGlobalEventListener : FsmStateAction
	{
		[Tooltip("event")]
		public FsmEvent eventt;

		public void BoltShutdown()
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void BoltStarted()
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectAttempt(UdpKit.UdpEndPoint endpoint)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectFailed(UdpKit.UdpEndPoint endpoint)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectRefused(UdpKit.UdpEndPoint endpoint)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectRefused(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectRequest(UdpKit.UdpEndPoint endpoint)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ConnectRequest(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void Connected(BoltConnection connection)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken, Bolt.IProtocolToken connectToken)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ControlOfEntityGained(BoltEntity entity)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ControlOfEntityGained(BoltEntity entity, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void ControlOfEntityLost(BoltEntity entity)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void Disconnected(BoltConnection connection)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void Disconnected(BoltConnection connection, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void EntityAttached(BoltEntity entity)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void EntityAttached(BoltEntity entity, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void EntityDetached(BoltEntity entity)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void EntityDetached(BoltEntity entity, Bolt.IProtocolToken token)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public bool PersistBetweenStartupAndShutdown()
		{
			return true;
		}
		public void PortMappingChanged(Bolt.INatDevice device, Bolt.IPortMapping portMapping)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void RegisterStreamChannels()
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void SceneLoadRemoteDone(BoltConnection connection)
		{
			Debug.Log ("Bolt Shutdown!");
		}
		public void StreamDataReceived(BoltConnection connection, UdpKit.UdpStreamData data)
		{
			Debug.Log ("Bolt Shutdown!");
		}

	}
}