using UnityEngine;
using System;
using System.Collections;

public class FsmProtocolToken : Bolt.IProtocolToken
{
    public enum PropertyType
    {
        Float,
        Int,
        Bool,
        String,
        Vector2,
        Vector3,
        Quaternion
    }

    public string[] propertyTypes;
    public object[] properties;

    public void SetProperties(object[] values, string[] types)
    {
        properties = values;
        propertyTypes = types;
    }

    public void GetProperties(object[] valueReference, string[] typeReference)
    {
        valueReference = properties;
        typeReference = propertyTypes;
    }

    public void Write(UdpKit.UdpPacket packet)
    {
        for (int i = 0; i < properties.Length; i++)
        {
            if (propertyTypes[i] == "Float")
            {
                packet.WriteFloat((float)properties[i]);
            }

            if (propertyTypes[i] == "Int")
            {
                packet.WriteInt((Int32)properties[i]);
            }

            if (propertyTypes[i] == "Bool")
            {
                packet.WriteBool((bool)properties[i]);
            }

            if (propertyTypes[i] == "String")
            {
                packet.WriteString((string)properties[i]);
            }

            if (propertyTypes[i] == "Vector2")
            {
                packet.WriteVector2((Vector2)properties[i]);
            }

            if (propertyTypes[i] == "Vector3")
            {
                packet.WriteVector3((Vector3)properties[i]);
            }

            if (propertyTypes[i] == "Quaternion")
            {
                packet.WriteQuaternion((Quaternion)properties[i]);
            }
        }
    }

    public void Read(UdpKit.UdpPacket packet)
    {
        for (int i = 0; i < properties.Length; i++)
        {
            if (propertyTypes[i] == "Float")
            {
                properties[i] = packet.ReadFloat();
            }

            if (propertyTypes[i] == "Int")
            {
                properties[i] = packet.ReadInt();
            }

            if (propertyTypes[i] == "Bool")
            {
                properties[i] = packet.ReadBool();
            }

            if (propertyTypes[i] == "String")
            {
                properties[i] = packet.ReadString();
            }

            if (propertyTypes[i] == "Vector2")
            {
                properties[i] = packet.ReadVector2();
            }

            if (propertyTypes[i] == "Vector3")
            {
                properties[i] = packet.ReadVector3();
            }

            if (propertyTypes[i] == "Quaternion")
            {
                properties[i] = packet.ReadQuaternion();
            }
        }
    }
}