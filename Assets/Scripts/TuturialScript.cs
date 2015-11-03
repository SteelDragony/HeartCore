using UnityEngine;
using System.Collections;

public class TuturialScript : MonoBehaviour {

    public int tuturialStage = 0;

    public AudioClip[] tuturialDialogue;

    AudioSource activeDialogue;

	// Use this for initialization
	void Start () {
        activeDialogue = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(activeDialogue.clip != tuturialDialogue[tuturialStage])
        {
            activeDialogue.Stop();
            activeDialogue.clip = tuturialDialogue[tuturialStage];
            activeDialogue.Play();
        }
        switch (tuturialStage)
        {
            case 0:
                if(!activeDialogue.isPlaying)
                {
                    tuturialStage++;
                }
                break;
            case 1:
                break;
            default:
                break;
        }
    }
}
