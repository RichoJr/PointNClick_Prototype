using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Create a custom game event system using Unity's ingame event system. It holds a function from a script attacted to the object sloted into the object variable.
[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

public class EventListener : MonoBehaviour
{
    public bool eventOn;
    public GameEvents gameEvent; // This variable references the GameEvents script.
    public CustomGameEvent feedBack; // This variable holds the data from the CustomGameEvent class, which includes the function and gameObject.

    // This function adds this listner script to the listener list
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    // This function removes this listner script to the listener list
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    //This function runs the slected function on the gameData(gameObject) when it is called.
    public void OnEventRaise(Component function, object gameData)
    {
        eventOn = true;
        feedBack.Invoke(function, gameData);
        eventOn = false;
    }
}
