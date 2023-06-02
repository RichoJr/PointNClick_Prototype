using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")] // Creates a new menu where game events can be created from.
public class GameEvents : ScriptableObject // Allows objects to be created with this script
{
    // Creates a list filled with the eventlistener scripts
    public List<EventListener> listeners = new List<EventListener>();

    //This function runs for the length of the listeners in the list and will call apon the OnEventRaise script in the EventListner script to run.
    public void Raise(Component function, object gameData)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaise(function, gameData);
        }
    }

    // These two functions add and remove the listeners from the listener list.
    public void AddListener(EventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(EventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
