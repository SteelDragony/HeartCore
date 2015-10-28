using UnityEngine;
using System.Collections;

public class holoTexture : MonoBehaviour {

    public Material holeMat;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        holeMat.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 10));
	}
}
