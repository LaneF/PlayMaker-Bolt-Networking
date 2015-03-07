using UnityEngine;
using Bolt;
using System;
using System.Collections;

/// <summary>
/// Bolt play maker utilities.
/// Shorcuts for general commands.
/// </summary>
namespace BoltPlayMakerUtils
{
    public static class Get
    {
        /// <summary>
        /// Input GameObject, returns the BoltEntity on the GameObject.
        /// </summary>
        /// <param name="go">The target GameObject</param>
        /// <returns>A Bolt Entity</returns>
	    public static BoltEntity Entity(this GameObject go)
	    {
            return go.GetComponent<BoltEntity>();
	    }

        /// <summary>
        /// Input GameObject and Property name, return the Property value.
        /// </summary>
        /// <param name="go">GameObject Entity target</param>
        /// <param name="propertyName">Name of the Property</param>
        /// <returns>The Property from the Entity</returns>
        public static object Property(this GameObject go, string propertyName)
        {
            var property = Get.Entity(go).GetState<IState>().GetDynamic(propertyName);
            return property;
        }
	}

    public static class Set
    {
        /// <summary>
        /// Sets a Property on a Bolt Entity.
        /// </summary>
        /// <param name="go">Target GameObject</param>
        /// <param name="propertyName">Property Name</param>
        /// <param name="value">Value to set Property to</param>
        public static void Property(GameObject go, string propertyName, object value)
        {
            Get.Entity(go).GetState<IState>().SetDynamic(propertyName, value);
        }
    }
}