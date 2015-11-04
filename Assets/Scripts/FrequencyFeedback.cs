using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrequencyFeedback : MonoBehaviour {

    public Slider frequencySlider;
    public float frequency = 105;
    public Transform gaugeNeedle;
    public float currentRotation = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        frequencySlider.value = (frequency - 105) / 20;
        float rotation = (frequency - 105) / 1;
        if(rotation > 90)
        {
            rotation = 90;
        }
        else if(rotation < -90)
        {
            rotation = -90;
        }
        gaugeNeedle.Rotate(0f, 0f, rotation - currentRotation);
        currentRotation = rotation;
	}
}
