using UnityEngine;
using System.Collections;

public class deskFan : MonoBehaviour {

    public float speed = -10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
