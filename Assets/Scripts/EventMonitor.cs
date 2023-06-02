using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EventMonitor : MonoBehaviour
{
    TriggerEntered trigEnter;
    public int eventCounter = 0;
    public bool humanEvent;
    public bool dogEvent;

    [Header("Events")]
    public List<GameEvents> HumanEvents = new List<GameEvents>();
    public List<GameEvents> DogEvents = new List<GameEvents>();
    public List<GameEvents> MultiEvents = new List<GameEvents>();
    public List<GameEvents> ActionPointEvents = new List<GameEvents>();

    private void Update()
    {
        EventChecker();
    }
    public void EventChecker()
    {
        //eventCounter = trigEnter.characterEvent;
        
        if (eventCounter == 1)
        {
            humanEvent = true;
            dogEvent = false;
            for (int i = 0; i < HumanEvents.Count; i++)
            {
                if (HumanEvents[i] == trigEnter.gameEvent)
                {
                    Debug.Log(trigEnter.gameEvent);
                }
            }
        }
        else if (eventCounter == 2)
        {
            dogEvent = true;
            humanEvent = false;
        }
        else if (eventCounter == 3)
        {
            humanEvent = true;
            dogEvent = true;
        }
        else
        {
            humanEvent = false;
            dogEvent = false;
            Debug.Log("Nothing");
        }
    }
}
