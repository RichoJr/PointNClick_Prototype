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
    //The four variables below control the are used to cast a Raycast at a certain distance only choose the seclected layers
    private Ray ray = new Ray();
    private RaycastHit rayHit = new RaycastHit();
    public float rayLength = 50f;
    public LayerMask maskCheck;
    public LayerMask characterCheck;

    //bools are used in true and false statements or 1 and 0
    public bool humanSelected;
    public bool dogSelected;

    //NavMeshAgents are use AI to move the gameobject they are on 
    public NavMeshAgent humanNav;
    public NavMeshAgent dogNav;

    //GameObjects are objects in the unity scene which can be controlled
    public GameObject humanUI;
    public GameObject dogUI;

    //Everything in the Update Function is done every frame
    void Update()
    {
        //This casts a ray from the mouse to the 3D environment in the game. Getting the mouse postion in the world.
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        //Everything in this if statement will only run of a left click of the mouse
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out rayHit, rayLength, maskCheck))
            {
                //If the raycast hits a player character then they become slected and their UI becomes active
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
                //If a character isn't hit but one is selected the left click will be the destination the player wishes them to move towards
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
