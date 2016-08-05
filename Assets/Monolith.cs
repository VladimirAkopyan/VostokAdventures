using UnityEngine;
using System.Collections;

public class Monolith : MonoBehaviour {

	private bool discovered = false;
	
	public bool encounter()
	{
		return discovered;
	}
	
	public void move()
	{
		this.GetComponent<Rigidbody>().AddForce(25000,0,0);
		this.GetComponent<Rigidbody>().AddRelativeTorque(0, 2500, 0);
	}
	public void stop()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

    void OnTriggerEnter(Collider other) {
        discovered= true;
		stop();
		Debug.Log("self- discovered");
	}
}
