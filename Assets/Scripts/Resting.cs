using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resting : MonoBehaviour
{
    public bool humanResting;
    public bool dogResting;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            humanResting = true;
        }

        if (other.gameObject.CompareTag("Dog"))
        {
            dogResting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            humanResting = false;
        }

        if (other.gameObject.CompareTag("Dog"))
        {
            dogResting = false;
        }
    }
}
