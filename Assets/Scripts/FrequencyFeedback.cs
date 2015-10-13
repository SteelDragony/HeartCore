using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrequencyFeedback : MonoBehaviour {

    public Slider frequencySlider;
    public float frequency = 105;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        frequencySlider.value = (frequency - 105) / 20;

	}
}
