using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;


/// <summary>
/// This is a global event reciever for Network events, handled on each individual session.
/// </summary>
[BoltGlobalBehaviour]
public class BoltNetworkGlobalCallbacks : Bolt.GlobalEventListener
{
    public override void Connected(BoltConnection connection)
    {
        Debug.Log("BPM " + connection.ToString() + " connected to us");
    }

    /// <summary>
    /// Callback triggered when the bolt simulation is shutting down.
    /// </summary>
    public override void BoltShutdown()
    {
        // alert that the server has collapsed...
        BoltConsole.Write("BPM Warning: Server Shutting Down...");
    }

    /// <summary>
    /// Callback triggered when the bolt simulation is starting.
    /// </summary>
    public override void BoltStarted()
    {
        // do some precalculation stuff with this...
        BoltConsole.Write("BPM Starting Game...");
    }

    public override void BoltStartFailed()
    {
        // (No API on this)...
        BoltConsole.Write("BPM BoltStartFailed()");
    }

    public override void BoltStartPending()
    {
        // (No API on this)...
        BoltConsole.Write("BPM BoltStartPending()");
    }

    /// <summary>
    /// Callback triggered when trying to connect to a remote endpoint
    /// </summary>
    /// <param name="endpoint"></param>
    public override void ConnectAttempt(UdpKit.UdpEndPoint endpoint)
    {
        BoltConsole.Write("BPM ConnectAttempt");
    }

    public override void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken)
    {
        // (No API on this)...
        BoltConsole.Write("BPM Connected");
    }

    public override void Connected(BoltConnection connection, Bolt.IProtocolToken acceptToken, Bolt.IProtocolToken connectToken)
    {
        // (No API on this)...
        BoltConsole.Write("BPM Connected");
    }

    /// <summary>
    /// Callback triggered when a connection to remote server has failed
    /// </summary>
    /// <param name="endpoint"></param>
    public override void ConnectFailed(UdpKit.UdpEndPoint endpoint)
    {
        BoltConsole.Write("BPM ConnectFailed");
    }

    /// <summary>
    /// Callback triggered when the connection to a remote server has been refused.
    /// </summary>
    /// <param name="endpoint"></param>
    public override void ConnectRefused(UdpKit.UdpEndPoint endpoint)
    {
        BoltConsole.Write("BPM ConnectRefused");
    }

    /// <summary>
    /// Callback triggered when the connection to a remote server has been refused.
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="token"></param>
    public override void ConnectRefused(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM ConnectRefused");
    }

    /// <summary>
    /// Callback triggered when this instance receives an incoming client connection
    /// </summary>
    /// <param name="endpoint"></param>
    public override void ConnectRequest(UdpKit.UdpEndPoint endpoint)
    {
        BoltConsole.Write("BPM ConnectRequest");
    }

    /// <summary>
    /// Callback triggered when this instance receives an incoming client connection
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="token"></param>
    public override void ConnectRequest(UdpKit.UdpEndPoint endpoint, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM ConnectRequest");
    }

    /// <summary>
    /// Callback triggered when this instance of bolt receieves control of a bolt entity
    /// </summary>
    /// <param name="entity"></param>
    public override void ControlOfEntityGained(BoltEntity entity)
    {
        BoltConsole.Write("BPM ControlOfEntityGained");
    }

    /// <summary>
    /// Callback triggered when this instance of bolt receieves control of a bolt entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="token"></param>
    public override void ControlOfEntityGained(BoltEntity entity, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM ControlOfEntityGained");
    }

    /// <summary>
    /// Callback triggered when this instance of bolt loses control of a bolt entity
    /// </summary>
    /// <param name="entity"></param>
    public override void ControlOfEntityLost(BoltEntity entity)
    {
        BoltConsole.Write("BPM ControlOfEntityLost");
    }

    /// <summary>
    /// Callback triggered when this instance of bolt loses control of a bolt entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="token"></param>
    public override void ControlOfEntityLost(BoltEntity entity, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM ControlOfEntityLost");
    }

    /// <summary>
    /// Callback triggered when disconnected from remote server
    /// </summary>
    /// <param name="connection"></param>
    public override void Disconnected(BoltConnection connection)
    {
        BoltConsole.Write("BPM Disconnected");
    }

    /// <summary>
    /// Callback triggered when disconnected from remote server
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="token"></param>
    public override void Disconnected(BoltConnection connection, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM Disconnected");
    }

    /// <summary>
    /// Callback triggered when a new entity is attached to the bolt simulation
    /// </summary>
    /// <param name="entity"></param>
    public override void EntityAttached(BoltEntity entity)
    {
        BoltConsole.Write("BPM EntityAttached");
    }

    /// <summary>
    /// Callback triggered when a new entity is attached to the bolt simulation
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="token"></param>
    public override void EntityAttached(BoltEntity entity, Bolt.IProtocolToken token)
    {
        BoltConsole.Write("BPM EntityAttached");
    }

    /// <summary>
    /// Callback triggered when a new entity is detached from the bolt simulation
    /// </summary>
    /// <param name="entity"></param>
    public override void EntityDetached(BoltEntity entity)
    {
        BoltConsole.Write("BPM EntityDetached");
    }

    /// <summary>
    /// Callback triggered when a new entity is detached from the bolt simulation
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="token"></param>
    public override void EntityDetached(BoltEntity entity, Bolt.IProtocolToken token)
    {
        // (No API on this)...
        BoltConsole.Write("BPM EntityDetached");
    }
    
    public override void EntityReceived(BoltEntity entity)
    {
        // (No API on this)...
        BoltConsole.Write("BPM EntityReceived");
    }

    public override void SceneLoadLocalBegin(string map)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SceneLoadLocalBegin");
    }

    public override void SceneLoadLocalBegin(string scene, Bolt.IProtocolToken token)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SceneLoadLocalBegin");
    }

    public override void SceneLoadLocalDone(string map)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SceneLoadLocalDone");
    }

    public override void SceneLoadLocalDone(string scene, Bolt.IProtocolToken token)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SceneLoadLocalDone");
    }

    /// <summary>
    /// Callback triggered when a remote connection has completely loaded the current scene
    /// </summary>
    /// <param name="connection"></param>
    public override void SceneLoadRemoteDone(BoltConnection connection)
    {
        BoltConsole.Write("BPM "+connection +" finished loading the scene.");
    }

    /// <summary>
    /// Callback triggered when a remote connection has completely loaded the current scene
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="token"></param>
    public override void SceneLoadRemoteDone(BoltConnection connection, Bolt.IProtocolToken token)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SceneLoadRemoteDone");
    }

    public override void SessionConnectFailed(UdpKit.UdpSession session)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SessionConnectFailed");
    }

    public override void SessionListUpdated(UdpKit.Map<System.Guid, UdpKit.UdpSession> sessionList)
    {
        // (No API on this)...
        BoltConsole.Write("BPM SessionListUpdated");
    }

    public override void StreamDataReceived(BoltConnection connection, UdpKit.UdpStreamData data)
    {
        // (No API on this)...
        BoltConsole.Write("BPM StreamDataReceived");
    }

    /// <summary>
    /// Callback when network router port mapping has been changed
    /// </summary>
    /// <param name="device"></param>
    /// <param name="portMapping"></param>
    public override void PortMappingChanged(Bolt.INatDevice device, Bolt.IPortMapping portMapping)
    {
        BoltConsole.Write("BPM PortMappingChanged");
    }

    /* Zeus global events
    public override void ZeusConnected(UdpKit.UdpEndPoint endpoint)
    {
        
    }

    public override void ZeusConnectFailed(UdpKit.UdpEndPoint endpoint)
    {
        
    }

    public override void ZeusDisconnected(UdpKit.UdpEndPoint endpoint)
    {
        
    }

    public override void ZeusNatProbeResult(UdpKit.NatFeatures features)
    {
  
    }
    */

    /// <summary>
    /// Override this method and return true if you want the event listener to keep being attached to Bolt even when Bolt shuts down and starts again.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override bool PersistBetweenStartupAndShutdown()
    {
        return true;
    }
}