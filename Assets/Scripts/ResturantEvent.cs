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

    public NavMeshAgent npcChef;

    public TriggerEntered trigEntSight;
    public TriggerEntered trigEntCaught;

    public GameEvents caughtDog;

    void Start()
    {
        
    }

    void Update()
    {
        if(trigEntSight.characterEvent == 2)
        {
            npcChef.SetDestination(trigEntSight.dogNav.transform.position);
            if(trigEntCaught.characterEvent == 2)
            {
                caughtDog.Raise(this, null);
            }
            
        }
    }
}