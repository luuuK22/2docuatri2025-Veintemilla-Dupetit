using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventManager
{

    private static Dictionary<EventType, Action> events =
        new Dictionary<EventType, Action>();

    public static void Subscribe(EventType type, Action callback)
    {
        if (!events.ContainsKey(type))
            events[type] = callback;
        else
            events[type] += callback;
    }

    public static void Unsubscribe(EventType type, Action callback)
    {
        if (events.ContainsKey(type))
            events[type] -= callback;
    }

    public static void Trigger(EventType type)
    {
        if (events.ContainsKey(type) && events[type] != null)
            events[type].Invoke();
    }
}


