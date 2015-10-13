using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FrequencyMeasure : MonoBehaviour
{
    ArrayList intervals;

    float lastTimePressed = 0f;

    public float targetDifference = 0.6f;
    public float accumulatedError = 0f;
    public float errorDecayRate = 0.1f;

    public List<AlarmLight> alarmLights;
    public FrequencyFeedback feedback;
    // Use this for initialization
    void Start()
    {
        intervals = new ArrayList();
        //alarmLights = new ArrayList();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float now = Time.time;
            float delta = now - lastTimePressed;
            lastTimePressed = now;
            intervals.Add(delta);

            accumulatedError += Mathf.Abs(delta - targetDifference);

            if (intervals.Count > 2)
                intervals.RemoveAt(0);
            CalculateAvarage();
        }
        /*
        if (accumulatedError > 0)
        {
            accumulatedError -= errorDecayRate * Time.deltaTime;
        }
        alarmLight.amlitude = accumulatedError;
        */
    }

    void CalculateAvarage()
    {
        if (intervals.Count < 2)
            return;

        float total = 0;

        for (int i = 0; i < intervals.Count - 1; i++)
        {
            total += (float)intervals[i];
        }

        float avg = total / (intervals.Count - 1);
        float frequency = 1 / avg * 60;

        foreach (AlarmLight L in alarmLights)
        {
            L.amlitude = Mathf.Abs(frequency - 104f) / 20;
        }

        //alarmLight.amlitude = Mathf.Abs(frequency - 104f)/10;
        feedback.frequency = frequency;
        Debug.Log(frequency);
        Debug.Log(avg);
    }
}
