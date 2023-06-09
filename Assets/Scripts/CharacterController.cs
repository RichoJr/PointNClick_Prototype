using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class CharacterController : MonoBehaviour
{
    //These are all for left click, which controls selecting a character and moving them.
    private Ray ray = new Ray();
    private RaycastHit rayHit = new RaycastHit();
    public float rayLength = 50f;
    public LayerMask maskCheck;

    public LayerMask characterCheck;
    public bool humanSelected;
    public bool dogSelected;

    public NavMeshAgent humanNav;
    public NavMeshAgent dogNav;

    public GameObject humanUI;
    public GameObject dogUI;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // This cast a ray from the mouse to the 3D environment in the game. Getting the mouse postion in the world.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out rayHit, rayLength, maskCheck))
            {
                if(Physics.Raycast(ray, out rayHit, rayLength, characterCheck))
                {
                    if (rayHit.transform.GameObject().name == "Human")
                    {
                        humanSelected = true;
                        dogSelected = false;
                        dogUI.SetActive(false);
                        humanUI.SetActive(true);
                    }
                    else if (rayHit.transform.GameObject().name == "Dog")
                    {
                        humanSelected = false;
                        dogSelected = true;
                        humanUI.SetActive(false);
                        dogUI.SetActive(true);
                    }
                }
                else
                {
                    if(humanSelected == true)
                    {
                        humanNav.enabled = true;
                        if(Physics.Raycast(ray, out rayHit))
                        {
                            humanNav.SetDestination(rayHit.point);
                            if(humanNav.destination == rayHit.point)
                            {
                                dogNav.enabled = false;
                            }
                        }

                    }
                    else if(dogSelected == true)
                    {
                        dogNav.enabled = true;
                        if (Physics.Raycast(ray, out rayHit))
                        {
                            dogNav.SetDestination(rayHit.point);
                            if (dogNav.destination == rayHit.point)
                            {
                                humanNav.enabled = false;
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
