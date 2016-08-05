using UnityEngine;
using System.Collections;


public class GUITest : MonoBehaviour {


	public Texture2D icon;
	public Texture2D playerIcon;
	public Texture2D mustasheIcon;
	public Texture2D assistantIcon;
	
	public BrokenJoint Dish;
	public BrokenJoint Tower;
	public BrokenJoint Panel1;
	public BrokenJoint Panel2;
	public BrokenJoint Panel3;
	public BrokenJoint Panel4;
	public BrokenJoint Arm1;
	public BrokenJoint Arm2;
	
	
	public ClipSwitch PlayerVoice;
	public ClipSwitch MVoice;
	public ClipSwitch AVoice;
	
	public GameObject Asteroid;
	
	public Rigidbody Player;
	public float speed;
	public float turnrate;
	public string SpeedDisplay;
	public string TurnDisplay;
	
	private bool Not_proud = true;
	private bool Not_tasked = true;
	private bool Not_cleared = true;
	private bool Not_assured = true;
	private bool Not_confirmed = true;
	private bool Sat_intact = true;
	private bool No_cat = true;
	private int progress = 0;
	private double timing = 0;
	
	void Start(){
		//timing= Time.time;
	}
	
	void OnGUI () {
		
		
		
		
		//Speed! for the player
		if (GUI.Button (new Rect (10,10, 100, 50), icon)) {
			print ("you clicked the icon");
		}
		 speed = (Player.velocity.magnitude*10)+8000;
		
		
		SpeedDisplay = speed.ToString();
		if(speed>0)
			SpeedDisplay= SpeedDisplay.Substring(0, 4);
		if (GUI.Button (new Rect (10,70, 100, 20), SpeedDisplay + " m/s")) {
			print ("you clicked the text button");
		}
		
		
		//First axis !!!!!WARNING VARIABLE REUSE!!!
		turnrate = Player.rigidbody.angularVelocity.z*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		if (GUI.Button (new Rect (120,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		
		if (GUI.Button (new Rect (120,10, 100, 50), icon)) {
			print ("you clicked the icon");
		}
		
		
		//Second axis !!!!!WARNING VARIABLE REUSE!!!
		turnrate = Player.rigidbody.angularVelocity.x*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		
		if (GUI.Button (new Rect (230,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		if (GUI.Button (new Rect (230,10, 100, 50), icon)) {
			print ("you clicked the icon");
		}
		
		//third axis
		turnrate = Player.rigidbody.angularVelocity.y*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		
		if (GUI.Button (new Rect (340,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		if (GUI.Button (new Rect (340,10, 100, 50), icon)) {
			print ("you clicked the icon");
		}
		
		
		/*
		//Voiceover Controll through Time
		if(Time.time > 7 &&Time.time < 15)
			MoustasheWrite("Congratulations comrade! \n You are ther first woman in space, ever. How are you feeling?");
		
		
		if(Time.time > 15.5 && Time.time < 18)
		{
			playerWrite("Proud to be here for my nation!");
			if(Not_proud)
				PlayerVoice.NextClip();
				Not_proud = false;
		}
		
		if(Time.time > 18 && Time.time < 40 )
		{
			MoustasheWrite("Glad to hear that!  Your mission is important to the world. \n Before we begin, an imperialist satellite that has been watching our affairs extensively.\n A too-close flyby could damage the antenna, accidentally...");
			if(Not_tasked)
			{
				MVoice.NextClip();
				Not_tasked = false;
			}
		}
		
		if(Time.time > 41 && Time.time < 44 )
		{
			playerWrite("So.. You want me to break it?");
			if(Not_cleared )
			{
				PlayerVoice.NextClip();
				Not_cleared = false;
			}
		}
		if(Time.time > 44.5 && Time.time < 55.5)
		{	
			MoustasheWrite("Yes, don't worry, we're almost certain   nothing will \n happen to Vostok spacecraft. Would you be kind enough \n to deal with the matter discretely?");
			if( Not_assured)
			{
				MVoice.NextClip();
				Not_assured = false;
			}
		}
		if(Time.time > 56 && Time.time < 59)
		{	
			playerWrite("Yes Sir");
			progress++;
			if(Not_confirmed)
			{
				PlayerVoice.NextClip();
				Not_confirmed = false;
			}
		}	
		*/
		if((Dish.Broken() ||Tower.Broken()||Arm1.Broken()||Arm2.Broken())&& Sat_intact ){ //&& Time.time > 59
			
			PlayerVoice.NextClip();
			Sat_intact = false;
			Asteroid.rigidbody.AddForce(-10000,0,0);
			Asteroid.renderer.enabled = true;
			playerWrite("Oops, my bad");
			timing= Time.time+3;
			progress++;
		}
		if(progress==1 &&((Time.time < timing)))
		{
			playerWrite("Oops, my bad");
			Debug.Log("progress is 1, first else entered");
			Debug.Log(Time.time - timing);
		}
		else if(progress==1 && ((Time.time > timing)))
		{
			progress++;
			timing=0;
			Debug.Log("progress is 1, second else entered");
			Debug.Log(Time.time - timing);
		}
		if(progress==2)
		{
			timing= Time.time+5;
			Debug.Log("progress is 2, third else entered");
			
			if(Time.time > timing  && ((Time.time - timing) < 11))
			{
				if(No_cat)
				{
					PlayerVoice.NextClip();
					Not_confirmed = false;
				}
				playerWrite("It crossed my path, just like a cat! That's a bad sign!");
			}
			else 
			{
				progress++;
				timing=0;
			}
			
		}
		
		
	}
	
	void playerWrite (string speech) {
		GUI.Button (new Rect (Screen.width*5/6,Screen.height*5/6,Screen.width/10,Screen.height/10), playerIcon);
		GUI.Button (new Rect (Screen.width*3/6,Screen.height*5/6, Screen.width*2/6, Screen.height/10), speech);
	}
	
	void MoustasheWrite (string speech) {
		GUI.Button (new Rect (Screen.width*1/15,Screen.height*5/6,Screen.width/10,Screen.height/10), mustasheIcon);
		GUI.Button (new Rect (Screen.width*1/15+Screen.width/10,Screen.height*5/6, Screen.width*2/6, Screen.height/10), speech);
	}

}