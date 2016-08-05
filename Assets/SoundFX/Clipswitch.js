#pragma strict
var myAudioClip: AudioClip[];

private var currentClip : int = 0;

 

function Start () {

   // LoopClips();

}



function NextClip() {

        GetComponent.<AudioSource>().clip = myAudioClip[currentClip];

        GetComponent.<AudioSource>().Play();
 

        yield WaitForSeconds (GetComponent.<AudioSource>().clip.length);


        currentClip++;

        if (currentClip >= myAudioClip.length)

            currentClip = 0;

}