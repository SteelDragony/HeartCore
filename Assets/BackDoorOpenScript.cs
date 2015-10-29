using UnityEngine;
using System.Collections;

public class BackDoorOpenScript : MonoBehaviour {

    public bool doorOpen = false;
    public GameObject leftDoor;
    public GameObject rightDoor;
    Vector3 leftDoorStart;
    Vector3 leftDoorOpen;
    Vector3 rightDoorStart;
    Vector3 rightDoorOpen;


	// Use this for initialization
	void Start () {
        leftDoorStart = leftDoor.transform.position;
        leftDoorOpen = leftDoorStart;
        leftDoorOpen.z += 5;
        rightDoorStart = rightDoor.transform.position;
        rightDoorOpen = rightDoorStart;
        rightDoorOpen.z -= 5;

    }
	
	// Update is called once per frame
	void Update () {
	    if(doorOpen)
        {
            leftDoor.transform.position = leftDoorOpen; 
        }
        else
        {
            leftDoor.transform.position = leftDoorStart;
        }
	}

    void OnTriggerStay(Collider other)
    {
        doorOpen = true;
    }

    void OnTriggerExit(Collider other)
    {
        doorOpen = false;
    }
}
