using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEntered : MonoBehaviour
{
    public int triggerID;
    public int amountCheck = 0;
    bool humanEntered = false;
    bool dogEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        if(triggerID == 0)
        {
            if(other.gameObject.CompareTag("Human"))
            {
                Debug.Log("Human has entered zone");
            }
        }
        if (triggerID == 1)
        {
            if (other.gameObject.CompareTag("Dog"))
            {
                Debug.Log("Dog has entered zone");
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
            }
        }
    }
}
