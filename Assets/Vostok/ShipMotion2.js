#pragma strict

var Torque = 100.0;
var Thrust = 1000.0;
var MaxSpeed = 10; 

//private var trueSpeed = 0.0;
//var strafeSpeed = 500.0;

var LeftRCS: ParticleSystem;
var RightRCS: ParticleSystem;
var TopRCS: ParticleSystem;
var BottRCS: ParticleSystem;
var MainEngine: ParticleSystem;
var MainEngine2: ParticleSystem;
var EngineLight: Light;
var LeftRCSSound: AudioSource;
var RightRCSSound: AudioSource;
var TopRCSSound: AudioSource;
var BottRCSSound: AudioSource;
var EngineSound: AudioSource;
private var prevYpos = 0.0;
private var prevXpos= 0.0;


function Update () {
	GetComponent.<Rigidbody>().angularDrag = 0;
	var speed = GetComponent.<Rigidbody>().velocity.magnitude;
    var pitch = Input.GetAxis("Pitch");
	var power = Input.GetAxis("Power");
	var yaw = Input.GetAxis("Yaw");
	//print(speed);//rigidbody.angularVelocity.magnitude
		
		//if the ship is thrusting RCS
		if((pitch!=0 || yaw!=0 )&& (GetComponent.<Rigidbody>().angularVelocity.magnitude < 0.3))
		{
			GetComponent.<Rigidbody>().AddRelativeTorque(0, yaw*Torque*Time.deltaTime, pitch*Torque*Time.deltaTime);
			if(pitch>0.0) 
			{
				BottRCS.enableEmission = true;
				TopRCS.enableEmission = false;
				if(BottRCSSound.isPlaying!=true)
				{
					BottRCSSound.Play();
				}
				TopRCSSound.Pause();
				
			}
			else if (pitch<0.0)
			{
				BottRCS.enableEmission = false;
				TopRCS.enableEmission = true;
				if(TopRCSSound.isPlaying!=true)
				{
					TopRCSSound.Play();
				}
				BottRCSSound.Pause();
			}
			if(yaw>0.0)
			{
				LeftRCS.enableEmission = true;
				RightRCS.enableEmission = false;
				if(LeftRCSSound.isPlaying!=true)
				{
					LeftRCSSound.Play();
				}
				RightRCSSound.Pause();
			}
			else if (yaw<0.0)
			{
				LeftRCS.enableEmission = false;
				RightRCS.enableEmission = true;
				if(RightRCSSound.isPlaying!=true)
				{
					RightRCSSound.Play();
				}
				LeftRCSSound.Pause();
			}
		}
		//if the ship is coast-turning
		else if((pitch!=0 || yaw!=0 )&& (GetComponent.<Rigidbody>().angularVelocity.magnitude > 0.3))
		{
			BottRCS.enableEmission = false;
			TopRCS.enableEmission = false;
			LeftRCS.enableEmission = false;
			RightRCS.enableEmission = false;
			BottRCSSound.Pause();
			TopRCSSound.Pause();
			LeftRCSSound.Pause();
			RightRCSSound.Pause();
		}
		//Ship is stopping
		else if((pitch==0 || yaw==0 )&& (GetComponent.<Rigidbody>().angularVelocity.magnitude > 0.02))
		{
			GetComponent.<Rigidbody>().angularDrag = 5;
			if(GetComponent.<Rigidbody>().angularVelocity.z>0.1) 
			{
				//rigidbody.AddRelativeTorque(0, 0, 0.1*Torque*Time.deltaTime);
				BottRCS.enableEmission = false;
				TopRCS.enableEmission = true;
				
				if(TopRCSSound.isPlaying!=true)
				{
					TopRCSSound.Play();
				}
				BottRCSSound.Pause();
			}
			else if (GetComponent.<Rigidbody>().angularVelocity.z<0.1)
			{
				//rigidbody.AddRelativeTorque(0, 0, -0.01*Torque*Time.deltaTime);
				BottRCS.enableEmission = true;
				TopRCS.enableEmission = false;
				if(BottRCSSound.isPlaying!=true)
				{
					BottRCSSound.Play();
				}
				TopRCSSound.Pause();
			}
			else
			{
				BottRCS.enableEmission = false;
				TopRCS.enableEmission = false;
				BottRCSSound.Pause();
				TopRCSSound.Pause();
			}
			if(GetComponent.<Rigidbody>().angularVelocity.y<0.1)
			{
				//rigidbody.AddRelativeTorque(0, 0.01*Torque*Time.deltaTime, 0);
				LeftRCS.enableEmission = true;
				RightRCS.enableEmission = false;
				if(LeftRCSSound.isPlaying != true)
				{
					LeftRCSSound.Play();
				}
				RightRCSSound.Pause();
			}
			else if (GetComponent.<Rigidbody>().angularVelocity.y>0.1)
			{
				//rigidbody.AddRelativeTorque(0, -0.01*Torque*Time.deltaTime, 0);
				LeftRCS.enableEmission = false;
				RightRCS.enableEmission = true;
				if(RightRCSSound.isPlaying != true)
				{
					RightRCSSound.Play();
				}
				LeftRCSSound.Pause();
			}
			else 
			{
				LeftRCS.enableEmission = false;
				RightRCS.enableEmission = false;
				LeftRCSSound.Pause();
				RightRCSSound.Pause();
			}
			
		}
		
		//Shut of the engines
		else
		{
			GetComponent.<Rigidbody>().angularDrag = 1;
			BottRCS.enableEmission = false;
			TopRCS.enableEmission = false;
			LeftRCS.enableEmission = false;
			RightRCS.enableEmission = false;
			BottRCSSound.Pause();
			TopRCSSound.Pause();
			LeftRCSSound.Pause();
			RightRCSSound.Pause();
		}
		if (power != 0)
		{
			MainEngine.enableEmission = true;
			MainEngine2.enableEmission = true;
			GetComponent.<Rigidbody>().AddRelativeForce(-Thrust*Time.deltaTime,0,0);
			
			if(EngineSound.isPlaying!=true)
			{
				EngineSound.Play();
			}
			EngineLight.intensity = 0.2;
		}
		else
		{
			MainEngine.enableEmission = false;
			MainEngine2.enableEmission = false;
			if(EngineSound.isPlaying== true)
			{
				EngineSound.Pause();
			}
			EngineLight.intensity = 0.0;
		}
		
		
			

		
		//else if(yaw>0 && (rigidbody.angularVelocity.y > -0.2) )

}
