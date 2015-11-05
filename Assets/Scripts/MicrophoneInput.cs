using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MicrophoneInput : MonoBehaviour {

    AudioClip micInput;
    AudioSource micRecording;

	// Use this for initialization
	void Start () {
        micRecording = GetComponent<AudioSource>();
        micInput = Microphone.Start(Microphone.devices[0], true, 1, 44100);
        micRecording.clip = micInput;
        micRecording.loop = true; // Set the AudioClip to loop
        micRecording.mute = true; // Mute the sound, we don't want the player to hear it
        //while (!(Microphone.GetPosition(AudioInputDevice) > 0)) { } // Wait until the recording has started
        micRecording.Play(); // Play the audio source!
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GetAveragedVolume());
	}

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        //micRecording.GetOutputData(data, 0);
        micInput.GetData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
