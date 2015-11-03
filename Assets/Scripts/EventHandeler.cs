using UnityEngine;
using System.Collections;

public class EventHandeler : MonoBehaviour {

    public AGravityMalfunction gravMalf;
    public LightFlickering lightsFlick;
    public float maxTimeBetweenEvents = 20f;
    public float minTimeBetweenEvents = 10f;

    public float timeTillEvent = 0f;

    float prevEventTime = 0f;


	// Use this for initialization
	void Start () {
        timeTillEvent = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("TestEvent"))
        {
            gravMalf.activateEvent(10f);
        }
        if(prevEventTime + timeTillEvent < Time.time)
        {
            prevEventTime = Time.time;
            gravMalf.activateEvent(4f);
            timeTillEvent = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
            lightsFlick.flickeringActive = true;
            StartCoroutine(stopFlicker(3));
        }
	}

    IEnumerator stopFlicker(float delay)
    {
        yield return new WaitForSeconds(delay);
        lightsFlick.flickeringActive = false;
        yield return null;
    }
}
