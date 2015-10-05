using UnityEngine;
using System.Collections;

public class VRMenu : MonoBehaviour {

    RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out hit, 500))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.tag == "MenuButton")
                {
                    Debug.Log("Hit A Button");
                    Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = false;
                        rb.AddForce(Vector3.up);
                    }

                }
                Debug.Log(hit);
            }
        }
	}
}
