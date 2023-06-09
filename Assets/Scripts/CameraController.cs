using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //These are all for right click, which controls moving the camera around the screen.
    public float dragingSpeed = 250f;

    public GameObject humanObject;
    public GameObject dogObject;

    public float zoomSpeed = 147.5f;

    [Header("Camera Rotation Transforms")]
    [Tooltip("Used to set the minimum x rotation value. Keep Y 180 and Z 0.")]
    public Quaternion minXRot;
    public Quaternion maxXRot;

    public CharacterController charCon;
    private void Start()
    {
        maxXRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 camPostion = new Vector3();
            camPostion.x = Input.GetAxis("Mouse X") * dragingSpeed * Time.deltaTime;
            camPostion.y = Input.GetAxis("Mouse Y") * dragingSpeed * Time.deltaTime;
            Camera.main.transform.Translate(-camPostion);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (charCon.humanSelected == true)
            {
                Camera.main.transform.position = new Vector3(humanObject.transform.position.x, transform.position.y, humanObject.transform.position.z);
            }
            if (charCon.dogSelected == true)
            {
                Camera.main.transform.position = new Vector3(dogObject.transform.position.x, transform.position.y, dogObject.transform.position.z);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (Camera.main.orthographicSize < 9.75f)
            {
                Camera.main.orthographicSize += 0.25f;
                Camera.main.transform.Rotate(Vector3.right * Camera.main.orthographicSize / 10f);
            }
            else
            {
                Camera.main.transform.rotation = maxXRot;
                Camera.main.orthographicSize = 10f;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Camera.main.orthographicSize > 5.25f)
            {
                Camera.main.orthographicSize -= 0.25f;
                Camera.main.transform.Rotate(Vector3.left * Camera.main.orthographicSize / 10f);
            }
            else
            {
                Camera.main.transform.localRotation = minXRot;
                Camera.main.orthographicSize = 5f;
            }
        }
        //if (Input.GetKey(KeyCode.E))
        //{
        //    //Camera.main.transform.Rotate(Vector3.forward * dragingSpeed * Time.deltaTime);
        //
        //    Vector3 camRotation = new Vector3();
        //    camRotation.z = -dragingSpeed * Time.deltaTime;
        //    Camera.main.transform.Rotate(-camRotation);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    //Camera.main.transform.Rotate(Vector3.back * dragingSpeed * Time.deltaTime);
        //
        //    Vector3 camRotation = new Vector3();
        //    camRotation.z = dragingSpeed * Time.deltaTime;
        //    Camera.main.transform.Rotate(-camRotation);
        //}
    }
}
