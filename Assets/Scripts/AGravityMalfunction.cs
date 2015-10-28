using UnityEngine;
using System.Collections;

public class AGravityMalfunction : MonoBehaviour {

    public AudioSource powerDownSound;
    public GameObject[] gravityObjects;
    public float duration = 5f;
    public float initialForce = 10f;
    float startTime = 0f;
    bool eventActive = false;

	// Use this for initialization
	void Start () {
        powerDownSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(eventActive == true && startTime + duration < Time.time)
        {
            eventActive = false;
            foreach (GameObject item in gravityObjects)
            {
                item.GetComponent<Rigidbody>().useGravity = true;
            }
        }
	}

    public void activateEvent(float time)
    {
        duration = time;
        startTime = Time.time;
        eventActive = true;
        powerDownSound.Play();
        foreach (GameObject item in gravityObjects)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(Vector3.up * initialForce);
        }
    }
}
