using UnityEngine;
using BoltPlayMakerUtils;
using System.Collections;

/// <summary>
/// This is a global event reciever for Network events, handled on each individual session.
/// </summary>
[BoltGlobalBehaviour]
public class BoltNetworkGlobalCallbacks : Bolt.GlobalEventListener
{
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