using UnityEngine;
using System.Collections;

public class FrequencyMeasure : MonoBehaviour
{

    ArrayList intervals;

    bool pressed = false;
    float lastTimePressed = 0f;

    public float targetDifference = 0.6f;
    public float accumulatedError = 0f;
    public float errorDecayRate = 0.1f;

    public AlarmLight alarmLight;

    // Use this for initialization
    void Start()
    {
        intervals = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        pressed = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pressed = true;
            float now = Time.time;
            float delta = now - lastTimePressed;
            lastTimePressed = now;
            intervals.Add(delta);

            accumulatedError += Mathf.Abs(delta - targetDifference);

            if (intervals.Count > 3)
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
        alarmLight.amlitude = Mathf.Abs(frequency - 104f)/10;

        Debug.Log(frequency);
        Debug.Log(avg);
    }
}
