using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = System.Random;
public class EventResult : MonoBehaviour
{
    //This is the 2nd method to generate this script. It is hard coded just to get this section done.
    delegate void EventHolder();

    List<EventHolder> eventHolder = new List<EventHolder>();

    public ResturantEvent restEvent;
    

    public bool eventWon;
    public bool eventLost;
    public bool on;

    public int minLP;
    public int maxLP;
    public int givenLP;
    void Start()
    {
        eventHolder.Add(ResturantEventStats);
    }
    public void EventSuccessful()
    {
        eventWon = true;
        for(int i = 0; i < eventHolder.Count; i++)
        {
            eventHolder[i].Invoke();
        }
    }
    public void EventUnsuccessful()
    {
        eventLost = true;
    }
    public void ResturantEventStats()
    {
        if(restEvent.success == true)
        {
            Random randomLPs = new Random();
            if (restEvent.eventDifficulty == 1)
            {
                minLP = randomLPs.Next(2, 4);
                maxLP = randomLPs.Next(5, 10);
            }
            else if (restEvent.eventDifficulty == 2)
            {
                minLP = randomLPs.Next(10, 12);
                maxLP = randomLPs.Next(13, 18);
            }
            else if (restEvent.eventDifficulty == 3)
            {
                minLP = randomLPs.Next(18, 20);
                maxLP = randomLPs.Next(21, 28);
            }
            givenLP = randomLPs.Next(minLP, maxLP);
            Debug.Log("MinLP: " + minLP + " MaxLP: " + maxLP + " GivenLP: " + givenLP);
            on = false;
        }
    }
    // 1st method needs to be further worked on. It would allow for new event scripts to be created then add without any new code.
    /*public bool eventWon;
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
      }*/
}
