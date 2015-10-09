using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {


    public float frequency = 60f;
    public float amlitude = 1f;
    Light alarmLight;

	// Use this for initialization
	void Start () {
        alarmLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        alarmLight.intensity = Mathf.Sin(Time.time * frequency) * amlitude + amlitude;
	}
}
