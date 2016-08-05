using UnityEngine;
using System.Collections;


public class GUITest : MonoBehaviour {


	public Texture2D Thrust;
	public Texture2D RotationY;
	public Texture2D RotationX;
	public Texture2D RotationZ;
	public Texture2D ART;
	public Texture2D INTRO;
	public Texture2D playerIcon;
	public Texture2D mustasheIcon;
	public Texture2D assistantIcon;
	public Texture2D DistanceIcon;
	
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
	
	public GameObject Asteroid;
	public Monolith monolith;
	public Light MonolithLight;
	
	public Rigidbody Player;
	public float speed;
	public float turnrate;
	public string SpeedDisplay;
	public string TurnDisplay;
	private string DistanceDisplay;
	
	
	private bool Not_proud = true;
	private bool Not_tasked = true;
	private bool Not_cleared = true;
	private bool Not_assured = true;
	private bool Not_confirmed = true;
	private bool Sat_intact = true;
	private bool No_cat = true;
	private bool Not_detected = true;
	private bool Not_unknown = true;
	private bool Not_hero = true;
	private bool Not_accepted = true;
	private bool Not_discovered = true;
	private bool Not_mproud = true;
	private bool Not_dissapeared = true;
	private bool Not_return = true;
	private bool ObjectivePresent = false;
	
	private int progress = 0;
	private double timing = 0;
	private float distance =0;
	
	void Start(){
		//timing= Time.time;
	}
	
	
	void OnGUI () {
		
		if (Not_detected == true)
			distance = Vector3.Distance(Arm2.transform.position, Player.transform.position)*10;
		else
			distance = Vector3.Distance(monolith.transform.position, Player.transform.position)*10;
		
		//Speed! for the player
		if (GUI.Button (new Rect (10,10, 100, 50), Thrust)) {
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
		turnrate = Player.GetComponent<Rigidbody>().angularVelocity.z*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		if (GUI.Button (new Rect (120,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		
		if (GUI.Button (new Rect (120,10, 100, 50), RotationZ)) {
			print ("you clicked the icon");
		}
		
		
		//Second axis !!!!!WARNING VARIABLE REUSE!!!
		turnrate = Player.GetComponent<Rigidbody>().angularVelocity.x*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		
		if (GUI.Button (new Rect (230,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		if (GUI.Button (new Rect (230,10, 100, 50), RotationX)) {
			print ("you clicked the icon");
		}
		
		//third axis
		turnrate = Player.GetComponent<Rigidbody>().angularVelocity.y*57;

		TurnDisplay = turnrate.ToString();
		if(turnrate!=0)
			TurnDisplay = TurnDisplay .Substring(0, 4);
		
		if (GUI.Button (new Rect (340,70, 100, 20), TurnDisplay  + " Deg/s")) {
			print ("you clicked the text button");
		}
		if (GUI.Button (new Rect (340,10, 100, 50), RotationY)) {
			print ("you clicked the icon");
		}
		
		DistanceDisplay = distance.ToString();
		if(distance!=0)
			DistanceDisplay = DistanceDisplay.Substring(0, 4);
		if(ObjectivePresent)
		{
			if (GUI.Button (new Rect (Screen.width*3/4,100, Screen.width/8, 20), DistanceDisplay  + "Meters")) {
				print ("you clicked the text button");
			}
			if (GUI.Button (new Rect (Screen.width*3/4,10, Screen.width/8, 90), DistanceIcon)) {
				print ("you clicked the icon");
			}
		}
		
		
		
		
		//controlls instructions
		if(Time.time < 8)
		{

			GUI.Label (new Rect (Screen.width*1/3,Screen.height*1/3,Screen.width/3,Screen.height/3), "<color=yellow><size=40> Controls: </size></color>\n\n \n <size=25>Use W A S D to rotate spacecraft</size> \n\n <size=25>Space bar fires the main engine</size>");
			GUI.Label (new Rect (Screen.width*1/3,Screen.height*1/6,Screen.width/3,Screen.height/3), INTRO);
		
		}
		
		//Voiceover Controll through Time
		if(Time.time > 8 &&Time.time < 15)

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
			MoustasheWrite("Glad to hear that!  Your mission is important to the world. \n Before we begin, an imperialist satellite that has \n been watching our affairs extensively.\n A too-close flyby could damage the antenna, accidentally...");
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
			ObjectivePresent = true;
			//progress++;
			if(Not_confirmed)
			{
				PlayerVoice.NextClip();
				Not_confirmed = false;
			}
		}	
		
		
			
		
		if((Dish.Broken() ||Tower.Broken()||Arm1.Broken()||Arm2.Broken())&& Sat_intact && Time.time > 59){ //
			
			PlayerVoice.NextClip();
			Sat_intact = false;
			Asteroid.GetComponent<Rigidbody>().AddForce(-10000,0,0);
			Asteroid.GetComponent<Renderer>().enabled = true;
			playerWrite("Oops, my bad");
			timing= Time.time+5;
			progress++;
			ObjectivePresent = false;
		}
		if(progress==1 &&((Time.time < timing)))
		{
			playerWrite("Oops, my bad");
			Debug.Log("progress is 1, first else entered");
			Debug.Log(Time.time - timing);
		}
		else if(progress==1 && ((Time.time > timing)))
		{
			Debug.Log(Time.time - timing);
			progress++;
			timing=0;
			Debug.Log("progress is 1");
			timing= Time.time+10;
		}
		
		if(progress==2)
		{
			Debug.Log("progress is 2");
			Debug.Log(Time.time - timing);
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+7;
			}
		}
		
		if(progress==3)
		{
			Debug.Log("progress is 3");
			playerWrite("Oh god! It nearly killed me! WHere did it come from? \n that's a bad sign!");
			if(No_cat)
				{
					Debug.Log("the cat!");
					PlayerVoice.NextClip();
					No_cat = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+10;
			}
		}
		
		if(progress==4)
		{
			Debug.Log("Detected!");
			AssistantWrite("We are detecting an unknown object 5 degrees ahead in your orbital path. \n you will encounter it shortly. \n please investigate");
			if(Not_detected)
				{
					Debug.Log("detected!");
					MVoice.NextClip();
					Not_detected = false;
					ObjectivePresent= true;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+5;
			}
		}

		MonolithLight.intensity = 1/2;
		if(progress==5)
		{
			Debug.Log("Unknown?!");
			playerWrite("Unknown? what do you mean?");
			if(Not_unknown)
				{
					Debug.Log("detected!");
					PlayerVoice.NextClip();
					Not_unknown = false;
					monolith.move();
					monolith.GetComponent<Renderer>().enabled = true;
					MonolithLight.intensity = 1/2;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+12;
			}
		}	
		
		if(progress==6)
		{
			Debug.Log("HEro!");
			MoustasheWrite("It's not American, and it's nothing like anything we've seen. \n Object might be of extra-terrestrial origin zn It is your chance to become a hero!");
			if(Not_hero)
				{
					Debug.Log("detected!");
					MVoice.NextClip();
					Not_hero = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+3;
			}
		}	
		
		if(progress==7)
		{
			Debug.Log("Yes Sir?!");
			playerWrite("Yes Sir!");
			if(Not_accepted)
				{
					Debug.Log("detected!");
					PlayerVoice.NextClip();
					Not_accepted = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+8;
			}
		}	
		
		if(progress==8 && monolith.encounter())
		{
			Debug.Log("I found it!");
			playerWrite("I found it!");
			if(Not_discovered)
				{
					timing= Time.time+7;
					Debug.Log("detected!");
					PlayerVoice.NextClip();
					Not_discovered = false;
					ObjectivePresent = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+7;
			}
		}	
		
		if(progress==9 )
		{
			MoustasheWrite("The motherland is proud!");
			if(Not_mproud)
				{
					timing= Time.time+30;
					Debug.Log("motherland proud!");
					MVoice.NextClip();
					Not_mproud = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+65;
			}
		}	
		
		if(progress==10 )
		{
			playerWrite("It just vanished!");
			if(Not_dissapeared)
				{
					timing= Time.time+5;
					Debug.Log("It just vanished!");
					PlayerVoice.NextClip();
					Not_dissapeared = false;
					monolith.GetComponent<Renderer>().enabled = false;
					MonolithLight.intensity = 0;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+7;
			}
		}	
		
		if(progress==11 )
		{
			MoustasheWrite("Are you mad? \n al-right, Return");
			if(Not_return)
				{
					timing= Time.time+7;
					Debug.Log("Return to the ground");
					MVoice.NextClip();
					Not_return = false;
				}
			if(Time.time > timing)
			{
				progress++;
				timing= Time.time+7;
			}
		}
		if(progress==12)
		{
			GUI.Label (new Rect (Screen.width*1/8,Screen.height*1/5,Screen.width/3,Screen.height/2), ART);
			//GUI.Button (new Rect (Screen.width*1/3,Screen.height*1/8,Screen.width/3,Screen.height/3), ART);
			GUI.Label (new Rect (Screen.width*1/3,Screen.height*1/5,Screen.width/3,Screen.height/2), "<color=yellow><size=30>Thank you for playing!: </size></color>\n\n <size=20>The game is made after the phrase uttered by Yuri Gagarin, the first man in space.\n 'I see no god up here', spawning much soviet propaganda art and many modern re-imaginings \n it is often used in typical pub 'Science vs Religion' arguments to point out that someone with sufficient knowledge and technological prowess can do great things and has no need for god. </size> \n\n ");
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
	void AssistantWrite (string speech) {
		GUI.Button (new Rect (Screen.width*1/15,Screen.height*5/6,Screen.width/10,Screen.height/10), assistantIcon);
		GUI.Button (new Rect (Screen.width*1/15+Screen.width/10,Screen.height*5/6, Screen.width*2/6, Screen.height/10), speech);
	}
}