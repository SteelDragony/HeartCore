using UnityEngine;
using System.Collections;

public class FrequencyMeasure : MonoBehaviour {

	ArrayList intervals;

	bool pressed = false;
	float lastTimePressed = 0f;

	// Use this for initialization
	void Start () {
		intervals = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		pressed = false;
		if( Input.GetKeyDown( KeyCode.UpArrow))
		{
			pressed = true;
			float now = Time.time;
			float delta = now - lastTimePressed;
			lastTimePressed = now;
			intervals.Add (delta);

			if(intervals.Count > 2)
				intervals.RemoveAt(0);
			CalculateAvarage();
		}
	}

	void CalculateAvarage()
	{
		if(intervals.Count < 2)
			return;

		float total = 0;

		for (int i = 0; i < intervals.Count-1; i++) {
			total += (float) intervals[i];
		}

		float avg = total / (intervals.Count-1);

		Debug.Log (1/avg * 60);
	}
}
