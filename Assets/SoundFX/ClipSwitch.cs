using UnityEngine;
using System.Collections;

public class ClipSwitch : MonoBehaviour {

	public AudioClip [] myAudioClip;
	public AudioSource PlaySource;
	private int currentClip = -1;
	
	void Start(){
	
		//myAudioClip = new AudioClip[10];

	}
	
	// Update is called once per frame
	public void NextClip () {
	    currentClip++;

        if (currentClip >= myAudioClip.Length)
			currentClip = 0;
			
		PlaySource.clip = (myAudioClip[currentClip]);
		PlaySource.Play();
	}
}
