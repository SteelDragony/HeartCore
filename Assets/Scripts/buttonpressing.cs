using UnityEngine;
using System.Collections;

public class buttonpressing : MonoBehaviour {

	public float score = 0f;
	public float amplitude = 1f;
	public float frequency = 1f;

	public float sinwave = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sinwave = Mathf.Sin(Time.time * frequency * 2 * Mathf.PI) * amplitude;
		if(Input.GetButtonDown("Fire1"))
		{
			score += sinwave;
		}

	}
}
