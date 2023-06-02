using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject animatedObject;
    public Animator animator;
    public string triggerName;

    public void BeginAnimation()
    {
        animatedObject.GetComponent<Animator>().SetTrigger(triggerName);
    }
}
