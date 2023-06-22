using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PointManager : MonoBehaviour
{
    //floats are fractions of numbers
    public float humanLP = 100;
    public float dogLP = 100;
    public float humanAP = 5;
    public float dogAP = 5;
    public float result;
   
    //bools are used in true and false statements or 1 and 0
    bool humanAlive = true;
    bool dogAlive = true;
    bool victory;
    bool lose;

    //GameObjects are objects in the unity scene which can be controlled
    public GameObject human;
    public GameObject dog;
    public GameObject gameOverMenu;

    //Text are text boxes which are edited through code
    public Text eventResultText;
    public Text humanLPText;
    public Text dogLPText;
    public Text humanApText;
    public Text dogAPText;

    //Sliders are sliders which can be editited through code
    public Slider humanLPSlider;
    public Slider dogLPSlider;
    public Slider humanAPSlider;
    public Slider dogAPSlider;

    //These are references for other scripts, so their information can be used in this script
    //eventMon is used to grab the humanEvent and dogEvent bools
    public EventMonitor eventMon;
    //eventResults is used to get the difficulty level of each puzzle and the eventWon and eventLost bools
    public EventResult eventResults;
    //resting is used to grab the humanResting and dogResting bools
    public Resting resting;

    //Everything in the Start Function is done once when the game launches
    void Start()
    {
        gameOverMenu.SetActive(false);
        //The StartCoroutine Function is used for creating timers that cause events to happen
        StartCoroutine(PointTimer());
    }

    //Everything in the Update Function is done every frame
    void Update()
    {
        ChangeUI();
        LifePoints();
        //The victory and lose bools are holding the true or false varibles from the eventWon and eventLost bools in the EventResult Script.
        victory = eventResults.eventWon;
        lose = eventResults.eventLost;
    }

    //An IEnumerator is the conntection for the StartCoroutine Function which counts done before doing the next line of code.
    IEnumerator PointTimer()
    {
        //This states that the current Life Points for the player equals itself -2, so 2 points are removed every time it runs.
        humanLP = humanLP - 2;
        dogLP = dogLP - 2;
        yield return new WaitForSeconds(3f);
        if(humanLP > 0 || dogLP > 0)
        {
            StartCoroutine(PointTimer());
        }
    }

    //This is the Life Point Function which is checking the status of the Life Points every frame
    public void LifePoints()
    {
        //These if Statements are checking if the Life Points ever go below zero. If they where to drop below zero the GameObject would be set to inactive(disapear but still in the level)
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
        //If both Characters become inactive the game ends using this if statement
        if(humanAlive == false && dogAlive == false)
        {
            gameOverMenu.SetActive(true);
        }
        ActionPoints();
    }

    //The ActionPoint Function monitors the action points for each character and if an event has been won or lost
    public void ActionPoints()
    {
        //These are checking if the action points are above zero, if an event is on and for which character
        if (humanAP > 0 && eventMon.humanEvent == true)
        {
            if (victory == true)
            {
                //If an Event is successful the character is given more lifepoints and an Action Point depending if they completed a hard puzzle or not
                eventResultText.text = "Event Successful";
                humanLP = humanLP + eventResults.givenLP;
                if(humanLP > 100)
                {
                    humanLP = 100;
                }
                if(eventResults.restEvent.eventDifficulty == 3)
                {
                    if(humanAP < 5)
                    {
                        humanAP++;
                    }
                }
                //These bools are returned to their respected scripts, so the code doesn't infinitely repeat itself
                eventMon.humanEvent = false;
                eventResults.eventWon = false;
            }
            if (lose == true)
            {
                //If an Event is lose the character is notified and can have another go at the event
                eventResultText.text = "Event Unsuccessful";
                eventMon.humanEvent = false;
                eventResults.eventLost = false;
            }
            
        }
        if (dogAP > 0 && eventMon.dogEvent == true)
        {
            if (victory == true)
            {
                eventResultText.text = "Event Successful";
                dogLP = dogLP + eventResults.givenLP;
                if(dogLP > 100)
                {
                    dogLP = 100;
                }
                if (eventResults.restEvent.eventDifficulty == 3)
                {
                    if(dogAP < 5)
                    {
                        dogAP++;
                    } 
                }
                eventMon.dogEvent = false;
                eventResults.eventWon = false;
            }
            if (lose == true)
            {
                eventResultText.text = "Event Unsuccessful";
                eventMon.dogEvent = false;
                eventResults.eventLost = false;
            }
        }
        CharacterRest();
    }

    //The CharacterRest Function allows the characters to regenerate action points but also takes some time, which allows there life points to drop faster
    public void CharacterRest()
    {
        //These check if the character is in the resting area and if their action points are below 5
        if (resting.humanResting == true)
        {
            if(humanAP < 5)
            {
                StartCoroutine(HumanRestingPeriod());
            }
        }
        if (resting.dogResting == true)
        {
            if (dogAP < 5)
            {
                StartCoroutine(DogRestingPeriod());
            }
        }
    }

    //The ChangeUI Function updates the UI for each characters life points and action points
    public void ChangeUI()
    {
        //Life Point UI Update
        humanLPSlider.value = humanLP / 100;
        humanLPText.text = humanLP.ToString() + "/100";
        dogLPSlider.value = dogLP / 100;
        dogLPText.text = dogLP.ToString() + "/100";

        //Action Point UI Update
        humanAPSlider.value = humanAP;
        humanApText.text = humanAP.ToString() + "/5";
        dogAPSlider.value = dogAP;
        dogAPText.text = dogAP.ToString() + "/5";
    }

    IEnumerator HumanRestingPeriod()
    {
        yield return new WaitForSeconds(4f);
        humanAP = 5;
    }

    IEnumerator DogRestingPeriod()
    {
        yield return new WaitForSeconds(6f);
        dogAP = 5;
    }
}