#pragma strict

var speed = 15; 

function Start () {

}

function Update () {

	transform.Rotate(Vector3.up * Time.deltaTime*speed/10);
}