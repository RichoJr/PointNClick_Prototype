using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBeign : MonoBehaviour
{
    public PointManager pointManager;

    public bool humanEntered;
    public bool dogEntered;
    public bool eventActive;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human" && humanEntered == false)
        {
            pointManager.humanAP--;
            humanEntered = true;
            eventActive = true;
        }
        if(other.gameObject.tag == "Dog" && dogEntered == false)
        {
            pointManager.dogAP--;
            dogEntered = true;
            eventActive = true;
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
            pointManager.dogAP--;
            dogEntered = false;
            eventActive = false;
        }
    }
}