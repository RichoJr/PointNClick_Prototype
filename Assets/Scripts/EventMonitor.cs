using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventMonitor : MonoBehaviour
{
    public int eventCounter = 0;
    public bool humanEvent;
    public bool dogEvent;
    public bool cantPlay;

    public Text eventNameText;

    public ResturantEvent restEvent;

    [Header("Triggers")]
    public List<TriggerEntered> eventTriggers = new List<TriggerEntered>();

    [Header("Events")]
    public List<GameEvents> HumanEvents = new List<GameEvents>();
    public List<GameEvents> DogEvents = new List<GameEvents>();
    public List<GameEvents> MultiEvents = new List<GameEvents>();
    public void EventChecker(TriggerEntered trigEnter)
    {
        if (eventTriggers.Contains(trigEnter))
        {
            eventCounter = trigEnter.characterEvent;

            if (eventCounter == 1)
            {
                for (int i = 0; i < HumanEvents.Count; i++)
                {
                    if (HumanEvents[i] == trigEnter.gameEvent)
                    {
                        humanEvent = true;
                        cantPlay = false;
                        eventNameText.text = trigEnter.gameEvent.name;
                    }
                    else
                    {
                        cantPlay = true;
                    }
                }
            }
            else if (eventCounter == 2)
            {
                for (int i = 0; i < DogEvents.Count; i++)
                {
                    if (DogEvents[i] == trigEnter.gameEvent)
                    {
                        dogEvent = true;
                        cantPlay = false;
                        eventNameText.text = trigEnter.gameEvent.name;
                    }
                    else
                    {
                        cantPlay = true;
                    }
                }
            }
            else if (eventCounter == 3)
            {
                for (int i = 0; i < MultiEvents.Count; i++)
                {
                    if (MultiEvents[i] == trigEnter.gameEvent)
                    {
                        humanEvent = true;
                        dogEvent = true;
                        cantPlay = false;
                        eventNameText.text = trigEnter.gameEvent.name;
                    }
                    else
                    {
                        cantPlay = true;
                    }
                }
            }
            else
            {
                humanEvent = false;
                dogEvent = false;
                Debug.Log("Nothing");
            }
        }  
    }
}
