using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public int humanLP = 100;
    public int dogLP = 100;
    public int humanAP = 5;
    public int dogAP = 5;
   
    bool eventSuccessful = true;
    bool eventActive;

    public GameObject human;
    public GameObject dog;

    public EventMonitor eventMon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PointTimer());
    }

    // Update is called once per frame
    void Update()
    {
        LifePoints();
    }

    IEnumerator PointTimer()
    {
        humanLP = humanLP - 2;
        dogLP = dogLP - 2;
        yield return new WaitForSeconds(3f);
        if(humanLP > 0 || dogLP > 0)
        {
            StartCoroutine(PointTimer());
        }
    }

    public void LifePoints()
    {
        if(humanLP <= 0)
        {
            human.SetActive(false);
        }
        if (dogLP <= 0)
        {
            dog.SetActive(false);
        }
        if(human.active == false && dog.active == false)
        {
            Debug.Log("Game Over");
        }

        ActionPoints();
    }

    public void ActionPoints()
    {
        if (humanAP > 0 && eventMon.humanEvent == true)
        {
            humanAP--;
            if (eventSuccessful == true)
            {
                /* Display UI for success*/
                Debug.Log("Event Successful");
                humanLP = humanLP + 10;
                // if(/*Action Points Given*/ == true)
                // {
                //     humanAP++;
                // }
            }
            else
            {
                /* Display UI for unsuccessful attempt*/
                //Debug.Log("Event Unsuccessful");
            }
            eventMon.humanEvent = false;
        }
        //if (dogAP > 0)
        //{
        //    eventStarted = eventMon.dogEvent;
        //    if (eventStarted == true)
        //    {
        //        dogAP--;
        //        if (eventSuccessful == true)
        //        {
        //            /* Display UI for success*/
        //            Debug.Log("Event Successful");
        //            dogLP = dogLP + 10;
        //            if (/*Action Points Given*/ == true)
        //            {
        //                dogAP++;
        //            }
        //        }
        //        else
        //        {
        //            /* Display UI for unsuccessful attempt*/
        //            Debug.Log("Event Unsuccessful");
        //        }
        //    }
        //}
        //else
        //{
        //    //Disable Events
        //    CharacterRest();
        //}
    }
    
   // public void CharacterRest()
   // {
   //     if(/* human is at home */)
   //     {
   //         if(humanAP < 5)
   //         {
   //             humanAP = 5;
   //         }
   //     }
   //     if (/* dog is at home */)
   //     {
   //         if (dogAP < 5)
   //         {
   //             dogAP = 5;
   //         }
   //     }
   // }

}