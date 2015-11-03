using UnityEngine;
using System.Collections;

public class holoTexture : MonoBehaviour {

    public Material holeMat;
    public bool lookTarget = false;
	// Use this for initialization
	void Start () {
        holeMat = gameObject.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        holeMat.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 10));
        if (lookTarget)
        {
            holeMat.color = new Color(holeMat.color.r, holeMat.color.g, holeMat.color.b, 0.7f);
        }
        else
        {
            holeMat.color = new Color(holeMat.color.r, holeMat.color.g, holeMat.color.b, 0.5f);
        } 
    }
}
