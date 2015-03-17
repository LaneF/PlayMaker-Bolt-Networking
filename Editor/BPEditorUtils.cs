using System.IO;
using Bolt;
using Bolt.Compiler;
using System.Collections.Generic;

public static class BPEditorUtils
{
    public static List<EventDefinition> GetEventList()
    {
        List<EventDefinition> allEvents = null;

        foreach (EventDefinition x in OpenProject().Events)
        {
            allEvents.Add(x);
        }

        return allEvents;
    }

    public static List<string> GetEventNames()
    {
        List<string> allEvents = null;

        foreach (EventDefinition x in OpenProject().Events)
        {
            allEvents.Add(x.Name);
        }

        return allEvents;
    }

    public static List<PropertyDefinition> GetEventProperties(EventDefinition x)
    {
        List<PropertyDefinition> P = x.Properties;

        return P;
    }

    public static Project OpenProject()
    {
        return File.ReadAllBytes("Assets/bolt/project.bytes").ToObject<Project>();
    }
}