using UnityEngine;
using System.Collections;

public class VRMenu : MonoBehaviour {

    RaycastHit hit;
    GameObject prevHitObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 500))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(prevHitObject != null && prevHitObject != hitObject)
            {
                UnFocusButton(prevHitObject);
            }
            if (hitObject.tag == "MenuButton")
            {
                prevHitObject = hitObject;
                holoTexture targetTextureScript = hitObject.GetComponent<holoTexture>();
                if(targetTextureScript != null)
                {
                    targetTextureScript.lookTarget = true;
                    
                }
                //Material buttonMat = hitObject.GetComponent<Renderer>().material;
                //buttonMat.color = new Color(buttonMat.color.r, buttonMat.color.g, buttonMat.color.b, 255f);
                if (Input.GetButtonDown("Fire1"))
                {

                    Debug.Log(hitObject.name);

                    Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = !rb.useGravity;
                        rb.AddForce(Vector3.up * 5);
                    }
                }
            }
        }
	}

    void UnFocusButton(GameObject button)
    {
        holoTexture targetScript = button.GetComponent<holoTexture>();
        if(targetScript != null)
        {
            targetScript.lookTarget = false;
        }
        prevHitObject = null;
    }

}
