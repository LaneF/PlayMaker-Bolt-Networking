using System.IO;
using Bolt;
using Bolt.Compiler;
using System;
using System.Collections.Generic;
using System.Reflection;

public static class BPEditorUtils
{
    public static List<EventDefinition> GetEventList()
    {
        List<EventDefinition> allEvents = new List<EventDefinition>();

        foreach (EventDefinition x in OpenProject().Events)
        {
            allEvents.Add(x);
        }

        return allEvents;
    }

    public static List<string> GetEventNameList()
    {
        List<string> allEvents = new List<string>();

        foreach (EventDefinition x in OpenProject().Events)
        {
            allEvents.Add(x.Name);
        }

        return allEvents;
    }

    public static EventDefinition GetEventByIndex(int index)
    {
        EventDefinition def = GetEventList()[index];
        return def;
    }

    public static List<PropertyDefinition> GetEventPropertyList(EventDefinition thisEvent)
    {
        List<PropertyDefinition> P = thisEvent.Properties;
        return P;
    }

    public static List<string> GetPropertyNameList(EventDefinition thisEvent)
    {
        List<PropertyDefinition> propList = GetEventPropertyList(thisEvent);
        List<string> names = new List<string>();

        for (int i = 0; i < propList.Count; i++)
        {
            names.Add(propList[i].Name);
        }

        return names;
    }

    public static PropertyDefinition GetPropertyInEventByIndex(EventDefinition thisEvent, int index)
    {
        List<PropertyDefinition> propList = GetEventPropertyList(thisEvent);
        PropertyDefinition p = propList[index];
        return p;
    }

    public static Project OpenProject()
    {
        return File.ReadAllBytes("Assets/bolt/project.bytes").ToObject<Project>();
    }
}