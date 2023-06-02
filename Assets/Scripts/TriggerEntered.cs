using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerEntered : MonoBehaviour
{
    public int triggerID;
    public int amountCheck = 0;
    public int characterEvent = 0;
    bool humanEntered = false;
    bool dogEntered = false;

    public NavMeshAgent humanNav;
    public NavMeshAgent dogNav;

    [Header("Event")]
    public GameEvents gameEvent;

    EventMonitor eventMon;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        if(triggerID == 0)
        {
            if(other.gameObject.CompareTag("Human"))
            {
                Debug.Log("Human has entered zone");
                characterEvent = 1;
                StartEvent();
            }
        }
        if (triggerID == 1)
        {
            if (other.gameObject.CompareTag("Dog"))
            {
                Debug.Log("Dog has entered zone");
                characterEvent = 2;
                StartEvent();

            }
        }
        if (triggerID == 2)
        {
            
            if (other.gameObject.CompareTag("Human") && humanEntered == false)
            {
                amountCheck++;
                humanEntered = true;
            }
            if (other.gameObject.CompareTag("Dog") && dogEntered == false)
            {
                amountCheck++;
                dogEntered = true;
            }
            if (amountCheck == 2)
            {
                Debug.Log("Both Human and Dog have entered zone");
                humanEntered = false;
                dogEntered = false;
                amountCheck = 0;
                characterEvent = 3;
                StartEvent();
            }
        }
        //eventMon.eventCounter = characterEvent;
        Debug.Log("characterE Event is : " + characterEvent);
    }

    private void OnTriggerExit()
    {
        //characterEvent = 0;
        Debug.Log(characterEvent);
    }
    
    public void StartEvent()
    {
        gameEvent.Raise(this, null);
    }
}
