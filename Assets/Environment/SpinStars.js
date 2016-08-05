#pragma strict

var speed = 5; 

function Start () {

}

function Update () {

	transform.Rotate(Vector2.up * Time.deltaTime*speed/10);
}