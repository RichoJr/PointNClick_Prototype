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

    //These are all for right click, which controls moving the camera around the screen.
    public float dragingSpeed = 250f;

    public GameObject humanObject;
    public GameObject dogObject;

    public float zoomSpeed = 147.5f;

    [Header("Camera Rotation Transforms")]
    [Tooltip("Used to set the minimum x rotation value. Keep Y 180 and Z 0.")]
    public Quaternion minXRot;
    public Quaternion maxXRot;

    private void Start()
    {
        maxXRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0f);
    }
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
                            Debug.Log("rayhit is now: " + rayHit.point);
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
                            Debug.Log("rayhit is now: " + rayHit.point);
                            if (dogNav.destination == rayHit.point)
                            {
                                humanNav.enabled = false;
                            }
                            
                        }
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 camPostion = new Vector3();
            camPostion.x = Input.GetAxis("Mouse X") * dragingSpeed * Time.deltaTime;
            camPostion.y = Input.GetAxis("Mouse Y") * dragingSpeed * Time.deltaTime;
            Camera.main.transform.Translate(-camPostion);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (humanSelected == true)
            {
                Camera.main.transform.position = new Vector3(humanObject.transform.position.x, transform.position.y, humanObject.transform.position.z);
            }
            if(dogSelected == true)
            {
                Camera.main.transform.position = new Vector3(dogObject.transform.position.x, transform.position.y, dogObject.transform.position.z);
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(Camera.main.orthographicSize < 10f)
            {
                Camera.main.transform.Rotate(Vector3.right * zoomSpeed * Time.deltaTime);
                Camera.main.orthographicSize += 0.25f;
            }
            else
            {
                Camera.main.transform.rotation = maxXRot;
                Camera.main.orthographicSize = 10f;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Camera.main.orthographicSize > 5f)
            {
                Camera.main.orthographicSize -= 0.25f;
                Camera.main.transform.Rotate(Vector3.left * zoomSpeed * Time.deltaTime);
            }
            else
            {
                Camera.main.transform.rotation = minXRot;
                Camera.main.orthographicSize = 5f;
            }
        }
    }
}
