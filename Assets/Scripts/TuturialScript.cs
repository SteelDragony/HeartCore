using UnityEngine;
using System.Collections;

public class TuturialScript : MonoBehaviour {

    public int tuturialStage = 0;

    public AudioClip[] tuturialDialogue;

    public FrequencyMeasure MainGameFrequency;
    public EventHandeler eventHandeler;
    public float frequency = 0;

    public AudioSource alarms;
    public AudioSource music;

    AudioSource activeDialogue;


    float freqTimeStart = 0;
    float freqTimeTarget = 10f;

	// Use this for initialization
	void Start () {
        activeDialogue = GetComponent<AudioSource>();
        //MainGameFrequency.enabled = false;
        eventHandeler.enabled = false;
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
                if(Input.GetButtonDown("Button"))
                {
                    tuturialStage++;
                    freqTimeStart = Time.time;
                }
                break;
            case 2:
                if(frequency < 85 || frequency > 125)
                {
                    freqTimeStart = Time.time;
                }
                if(freqTimeStart + freqTimeTarget < Time.time)
                {
                    tuturialStage++;
                }
                break;
            case 3:
                if(!activeDialogue.isPlaying)
                {
                    tuturialStage++;
                    freqTimeTarget = 30f;
                    freqTimeStart = Time.time;
                    eventHandeler.enabled = true;
                }
                break;
            case 4:
                if (frequency < 85 || frequency > 125)
                {
                    freqTimeStart = Time.time;
                }
                if (freqTimeStart + freqTimeTarget < Time.time)
                {
                    tuturialStage++;
                }
                break;
            case 5:
                if (!activeDialogue.isPlaying)
                {
                    tuturialStage++;
                    alarms.enabled = true;
                }
                break;
            case 6:
                if(!activeDialogue.isPlaying)
                {
                    music.volume = 0.5f;
                }
                break;
            default:
                break;
        }
    }
}
