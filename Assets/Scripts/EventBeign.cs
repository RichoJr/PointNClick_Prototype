using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBeign : MonoBehaviour
{
    public PointManager pointManager;

    public bool humanEntered;
    public bool dogEntered;
    public bool eventActive;

    public bool eventClosed;
    private void OnTriggerEnter(Collider other)
    {
        if(eventClosed == false)
        {
            if (other.gameObject.tag == "Human" && humanEntered == false)
            {
                if(pointManager.humanAP > 0)
                {
                    pointManager.humanAP--;
                    humanEntered = true;
                    eventActive = true;
                }
            }
            if (other.gameObject.tag == "Dog" && dogEntered == false)
            {
                if (pointManager.dogAP > 0)
                {
                    pointManager.dogAP--;
                    dogEntered = true;
                    eventActive = true;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Human" && humanEntered == true)
        { 
            humanEntered = false;
            eventActive = false;
        }
        if (other.gameObject.tag == "Dog" && dogEntered == true)
        {
            dogEntered = false;
            eventActive = false;
        }
    }
}
