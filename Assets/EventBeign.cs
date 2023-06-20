using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBeign : MonoBehaviour
{
    public PointManager pointManager;

    public bool humanEntered;
    public bool dogEntered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human" && humanEntered == false)
        {
            pointManager.humanAP--;
            humanEntered = true;
        }
        if(other.gameObject.tag == "Dog" && dogEntered == false)
        {
            pointManager.dogAP--;
            dogEntered = true;
        }
    }
}
