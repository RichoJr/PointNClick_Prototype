using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ResturantEvent : MonoBehaviour
{
    [Tooltip("ID:   1 = Easy    2 = Moderate    3 = Hard")]
    [Range(1f, 3f)]
    public int eventDifficulty;
    public int eventItems;

    public bool success;
    public bool massiveFail;
    public bool sightEventStart;
    public bool reset;

    public NavMeshAgent npcChef;

    public TriggerEntered trigEntSight;
    public TriggerEntered trigEntCaught;
    public TriggerEntered trigHumanConvo;

    public EventResult eventResult;
    public PointManager pointManager;
    public EventBeign eventBegan;
    public EventMonitor eventMonitor;

    public GameObject itemText;
    public GameObject startPosition;
    public GameObject doorStandPos;
    public GameObject chefConvoPos;
    public GameObject dogEventStarter;
    public List<GameObject> itemsToBeCollected;

    public GameEvents dogResetEvent;

    Transform lastSeenPos;

    [System.Obsolete]
    void Update()
    {
        if (itemText.active == true)
        {
            StartCoroutine(TextDisplayTime());
        }
        if (eventBegan.eventActive == true)
        {
            EventOneBegin();
        }
    }

    [System.Obsolete]
    public void EventOneBegin()
    {
        if (reset == false)
        {
            if (trigEntSight.characterEvent == 2)
            {
                sightEventStart = true;
                lastSeenPos = trigEntSight.dogNav.GetComponent<Transform>();
                npcChef.SetDestination(trigEntSight.dogNav.transform.position);
                if (trigEntCaught.characterEvent == 2)
                {
                    npcChef.gameObject.SetActive(false);
                    eventBegan.dogEntered = false;
                    ResetEvent();
                    eventResult.EventUnsuccessful();
                    dogResetEvent.Raise(this, null);
                    npcChef.gameObject.SetActive(true);
                    trigEntCaught.characterEvent = 0;
                    trigEntSight.characterEvent = 0;
                }
            }
            if (sightEventStart == true)
            {
                if (trigEntSight.characterEvent == 0)
                {
                    sightEventStart = false;
                    StartCoroutine(SightTimer());
                }
            }
            if (eventItems == itemsToBeCollected.Count)
            {
                success = true;
                dogEventStarter.GetComponent<EventBeign>().eventClosed = true;
                trigHumanConvo.gameObject.GetComponent<EventBeign>().eventClosed = true;
                eventResult.EventSuccessful();
                eventItems++;
                success = false;
            }
        }
        reset = false;
    }
    IEnumerator TextDisplayTime()
    {
        yield return new WaitForSeconds(2f);
        itemText.SetActive(false);
    }
    IEnumerator SightTimer()
    {
        yield return new WaitForSeconds(1f);
        npcChef.SetDestination(startPosition.transform.position); 
    }
    public void ResetEvent()
    {
        reset = true;
        npcChef.transform.position = startPosition.transform.position;
        for (int i = 0; i < itemsToBeCollected.Count; i++)
        {
            itemsToBeCollected[i].SetActive(true);
        }
        eventItems = 0;
    }

    public void ItemCollected()
    {
        eventItems++;
    }
    public void Conversation()
    {
        trigHumanConvo.humanNav.SetDestination(doorStandPos.transform.position);
        npcChef.SetDestination(chefConvoPos.transform.position);
        StartCoroutine(ConvoTime());
    }

    IEnumerator ConvoTime()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(10f);
        Debug.Log("TimeDone");
        npcChef.SetDestination(startPosition.transform.position);
    }
}
