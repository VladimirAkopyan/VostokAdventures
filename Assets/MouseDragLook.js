#pragma strict


var target : Transform;
var distance = 5.0;
var xSpeed = 125.0;
var ySpeed = 50.0;
 
private var x = 0.0;
private var y = 0.0;
private var rotation= Quaternion.Euler(y, x, 0);;
private var position= rotation * Vector3(0.0, 0.0, -distance) + target.position;;
 
@script AddComponentMenu("Camera-Control/Mouse Orbit")
 
function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;
}
 
function LateUpdate () {
    if (target && Input.GetMouseButton(0) ) { 
        x += Input.GetAxis("Mouse X") * xSpeed * 0.2;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.05; 
		distance+= Input.GetAxis("Mouse ScrollWheel")*10;
        rotation = Quaternion.Euler(y, x, 0);
        position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        transform.rotation = rotation;
        transform.position = position;
    }
	else if(target)
	{
		distance+= Input.GetAxis("Mouse ScrollWheel")*10;
		position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
		transform.rotation = rotation;
        transform.position = position;
	}
	
}