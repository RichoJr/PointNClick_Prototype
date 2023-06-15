using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TriggerEntered : MonoBehaviour
{
    [Tooltip("ID:       0 = Human     1 = Dog     2 = Both")]
    [Range(0f, 2f)]
    public int triggerID;
    public int amountCheck = 0;
    public int characterEvent = 0;
    bool humanEntered = false;
    bool dogEntered = false;

    public NavMeshAgent humanNav;
    public NavMeshAgent dogNav;

    [Header("Event")]
    public GameEvents gameEvent;

    public EventMonitor eventMon;

    private void OnTriggerEnter(Collider other)
    {
        if(triggerID == 0)
        {
            if(other.gameObject.CompareTag("Human"))
            {
                characterEvent = 1;
                StartEvent();
            }
        }
        if (triggerID == 1)
        {
            if (other.gameObject.CompareTag("Dog"))
            {
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
                humanEntered = false;
                dogEntered = false;
                amountCheck = 0;
                characterEvent = 3;
                StartEvent();
            }
        }
        //eventMon.eventCounter = characterEvent;
    }

    private void OnTriggerExit()
    {
        //characterEvent = 0;
    }
    
    public void StartEvent()
    {
        eventMon.EventChecker(this);
        if (eventMon.cantPlay == true)
        {
            return;
        }
        gameEvent.Raise(this, null);
    }
}
