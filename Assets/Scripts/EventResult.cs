using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EventResult : MonoBehaviour
{
    public bool eventWon;
    public bool eventLost;

    int difficultyLevel;

    string difficultyString;

    public string[] difficultiy = new string[3];

    public MonoBehaviour[] eventScriptList = new MonoBehaviour[1];

    public int[] diffLevelStorage = new int[1];
    public string[] diffStringStorage = new string[1];

    public Array[] arrayArray = new Array[3];

    [Header("Events Scripts")]
    public ResturantEvent resturantEvent;
    private void Start()
    {
        difficultiy[0] = "Easy";
        difficultiy[1] = "Moderate";
        difficultiy[2] = "Hard";
        arrayArray[0] = eventScriptList;
        arrayArray[1] = diffLevelStorage;
        arrayArray[2] = diffStringStorage;
        EventSuccessful();
    }
    public void EventSuccessful()
    {
        eventWon = true;
        for (int i = 0; i < difficultiy.Length; i++)
        {
            if (arrayArray[i] == eventScriptList)
            {
                Debug.Log("They Match");
            }
            if (difficultyString == "Easy")
            {

            }
            else if (difficultyString == "Moderate")
            {

            }
            else if (difficultyString == "Hard")
            {

            }
        }
    }
    public void EventUnsuccessful()
    {
        eventLost = true;
    }
    public void GiveActionPoints()
    {

    }
    public void GetEventDifficulties()
    {
        for (int i = 0; i < eventScriptList.Length; i++)
        {
            if (eventScriptList[i] == resturantEvent)
            {
                diffLevelStorage[i] = resturantEvent.eventDifficulty;
                DifficultiyCheck();
            }
        }
    }

    public void DifficultiyCheck()
    {
        for (int i = 0; i < eventScriptList.Length; i++)
        {
            if (diffLevelStorage[i] == 1)
            {
                diffStringStorage[i] = "Easy";
            }
            if (diffLevelStorage[i] == 2)
            {
                diffStringStorage[i] = "Moderate";
            }
            if (diffLevelStorage[i] == 3)
            {
                diffStringStorage[i] = "Hard";
            }
        }
    }
}
