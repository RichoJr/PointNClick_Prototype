using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMonitor : MonoBehaviour
{
    public TriggerEntered trigEnter;
    public bool humanEvent;
    public bool dogEvent;

    void Update()
    {
        EventChecker();
    }
    public void EventChecker()
    {
        if(trigEnter.characterEvent == 1)
        {
            humanEvent = true;
            dogEvent = false;
        }
        if (trigEnter.characterEvent == 2)
        {
            dogEvent = true;
            humanEvent = false;
        }
        if (trigEnter.characterEvent == 3)
        {
            humanEvent = true;
            dogEvent = true;
        }
    }
}
