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
    public bool eventStarted;

    public GameObject human;
    public GameObject dog;

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
        Debug.Log(humanLP);
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
        if(humanAP > 0)
        {
            
        }
        if (dogAP > 0)
        {
            
        }
    }
}
