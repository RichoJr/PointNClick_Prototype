using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ResturantEvent : MonoBehaviour
{
    [Tooltip("ID:   1 = Easy    2 = Moderate    3 = Hard")]
    [Range(1f, 3f)]
    public int eventDifficulty;

    public bool success;
    public bool massiveFail;
    public bool sightEventStart;

    public NavMeshAgent npcChef;

    public TriggerEntered trigEntSight;
    public TriggerEntered trigEntCaught;

    public EventResult eventResult;
    public PointManager pointManager;
    public EventBeign eventBegan;

    public GameObject startPosition;

    Transform lastSeenPos;

    void Update()
    {
        EventOneBegin();  
    }
    public void EventOneBegin()
    {
        if (trigEntSight.characterEvent == 2)
        {
            sightEventStart = true;
            lastSeenPos = trigEntSight.dogNav.GetComponent<Transform>();
            npcChef.SetDestination(trigEntSight.dogNav.transform.position);
            if (trigEntCaught.characterEvent == 2)
            {
                npcChef.SetDestination(lastSeenPos.transform.position);
                eventBegan.dogEntered = false;
                eventResult.EventUnsuccessful();
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
    }
    IEnumerator SightTimer()
    {
        yield return new WaitForSeconds(3f);
        npcChef.SetDestination(startPosition.transform.position); 
    }
}
