using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public float humanLP = 100;
    public float dogLP = 100;
    public float humanAP = 5;
    public float dogAP = 5;
    public float result;
   
    bool eventSuccessful = true;
    bool humanAlive = true;
    bool dogAlive = true;

    public GameObject human;
    public GameObject dog;

    public Text eventResultText;
    public Text humanLPText;
    public Text dogLPText;
    public Text humanApText;
    public Text dogAPText;

    public Slider humanLPSlider;
    public Slider dogLPSlider;
    public Slider humanAPSlider;
    public Slider dogAPSlider;

    public EventMonitor eventMon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PointTimer());
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUI();
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
            humanAlive = false;
        }
        if (dogLP <= 0)
        {
            dog.SetActive(false);
            dogAlive = false;
        }
        if(humanAlive == false && dogAlive == false)
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
                eventResultText.text = "Event Successful";
                humanLP = humanLP + 10;
                // if(/*Action Points Given*/ == true)
                // {
                //     humanAP++;
                // }
            }
            else
            {
                eventResultText.text = "Event Unsuccessful";
            }
            eventMon.humanEvent = false;
        }
        if (dogAP > 0 && eventMon.dogEvent == true)
        {
            dogAP--;
            if (eventSuccessful == true)
            {
                eventResultText.text = "Event Successful";
                dogLP = dogLP + 10;
                //if (/*Action Points Given*/ == true)
                //{
                //    dogAP++;
                //}
            }
            else
            {
                eventResultText.text = "Event Unsuccessful";
            }
            eventMon.dogEvent = false;
        }
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

    public void ChangeUI()
    {
        humanLPSlider.value = humanLP / 100;
        humanLPText.text = humanLP.ToString() + "/100";
        dogLPSlider.value = dogLP / 100;
        dogLPText.text = dogLP.ToString() + "/100";

        humanAPSlider.value = humanAP;
        humanApText.text = humanAP.ToString() + "/5";
        dogAPSlider.value = dogAP;
        dogAPText.text = dogAP.ToString() + "/5";
    }
}