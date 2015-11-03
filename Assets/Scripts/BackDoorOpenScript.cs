using UnityEngine;
using System.Collections;

public class BackDoorOpenScript : MonoBehaviour {

    public bool doorOpen = false;
    bool prevState = false;
    public float doorMoveDistance =1;
    public GameObject leftDoor;
    public GameObject rightDoor;
    Vector3 leftDoorStart;
    Vector3 leftDoorOpen;
    Vector3 rightDoorStart;
    Vector3 rightDoorOpen;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

	// Use this for initialization
	void Start () {
        leftDoorStart = leftDoor.transform.position;
        leftDoorOpen = leftDoorStart;
        leftDoorOpen.z += doorMoveDistance;
        rightDoorStart = rightDoor.transform.position;
        rightDoorOpen = rightDoorStart;
        rightDoorOpen.z -= doorMoveDistance;

    }
	
	// Update is called once per frame
	void Update () {
	    if(doorOpen && doorOpen != prevState)
        {
            StartCoroutine(animateDoors());
            prevState = doorOpen;
            //leftDoor.transform.position = leftDoorOpen;
            //rightDoor.transform.position = rightDoorOpen;
        }
        else if(!doorOpen && doorOpen != prevState)
        {
            StartCoroutine(animateDoors());
            prevState = doorOpen;
            //leftDoor.transform.position = leftDoorStart;
            //rightDoor.transform.position = rightDoorStart;
        }
	}

    IEnumerator animateDoors()
    {
        if (doorOpen)
        {
            doorOpenSound.Play();
            for (float i = 0; i < 1; i += 0.05f)
            {
                leftDoor.transform.position = Vector3.Lerp(leftDoorStart, leftDoorOpen, i);
                rightDoor.transform.position = Vector3.Lerp(rightDoorStart, rightDoorOpen, i);
                yield return new WaitForSeconds(0.05f);
            }
            leftDoor.transform.position = leftDoorOpen;
            rightDoor.transform.position = rightDoorOpen;
        }
        else
        {
            doorCloseSound.Play();
            for (float i = 0; i < 1; i += 0.05f)
            {
                leftDoor.transform.position = Vector3.Lerp(leftDoorOpen, leftDoorStart, i);
                rightDoor.transform.position = Vector3.Lerp(rightDoorOpen, rightDoorStart, i);
                yield return new WaitForSeconds(0.05f);
            }
            leftDoor.transform.position = leftDoorStart;
            rightDoor.transform.position = rightDoorStart;
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
