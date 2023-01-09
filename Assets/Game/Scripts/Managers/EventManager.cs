using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum EventEnums
{
    CLAW_COLLIDER_COLLISION_ENTER,
    CLAW_ON_CLAW_CLOSED,
    CLAW_ON_CLAW_OPENED,
    CLAW_FINISH_MOVE_TO_DROP_ZONE,

    PRIZE_ON_DROPPED
}

[System.Serializable]
public class CustomEvent : UnityEvent<Hashtable> { }

public class EventManager : MonoBehaviour
{
    private Dictionary<EventEnums, CustomEvent> eventDictionary;

    public static EventManager instance;

    private Dictionary<EventEnums, List<UnityAction<Hashtable>>> onceEventDictionary;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

        InitEvents();
    }

    private void InitEvents()
    {
        eventDictionary = new Dictionary<EventEnums, CustomEvent>();
        onceEventDictionary = new Dictionary<EventEnums, List<UnityAction<Hashtable>>>();
        foreach(EventEnums eventEnum in System.Enum.GetValues(typeof(EventEnums)))
        {
            eventDictionary.Add(eventEnum, new CustomEvent());
            onceEventDictionary.Add(eventEnum, new List<UnityAction<Hashtable>>());
        }
    }

    public void AddListener(EventEnums eventName, UnityAction<Hashtable> listener)
    {
        CustomEvent currentEvent;
        eventDictionary.TryGetValue(eventName, out currentEvent);

        if (currentEvent == null)
            return;

        currentEvent.AddListener(listener);
    }

    public void RemoveListener(EventEnums eventName, UnityAction<Hashtable> listener)
    {
        CustomEvent currentEvent;
        eventDictionary.TryGetValue(eventName, out currentEvent);

        if (currentEvent == null)
            return;

        currentEvent.RemoveListener(listener);
    }

    public void InvokeEvent(EventEnums eventName, Hashtable hashtable = null)
    {
        CustomEvent currentEvent;
        eventDictionary.TryGetValue(eventName, out currentEvent);

        if (currentEvent == null)
            return;

        currentEvent.Invoke(hashtable);

        var onceEventList = onceEventDictionary[eventName];

        for(int i=0;i< onceEventList.Count; i++)
        {
            currentEvent.RemoveListener(onceEventList[i]);
        }

        onceEventList.Clear();     
    }

    public void AddListenerOnce(EventEnums eventName, UnityAction<Hashtable> listener)
    {
        CustomEvent currentEvent;
        eventDictionary.TryGetValue(eventName, out currentEvent);

        if (currentEvent == null)
            return;
        

        currentEvent.AddListener(listener);
        onceEventDictionary[eventName].Add(listener);

    }

}

