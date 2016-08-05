using UnityEngine;
using System.Collections;

public class BrokenJoint : MonoBehaviour {
	
	private bool JointBroken = false;
	
	public bool Broken(){
		
		return JointBroken;

	}
		
    void OnJointBreak(float breakForce) {
		JointBroken = true;
        Debug.Log("Comms Dish has just been broken off the sattelite!, force: " + breakForce);
    }

}
