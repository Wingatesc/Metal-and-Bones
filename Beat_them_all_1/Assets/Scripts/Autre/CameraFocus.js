#pragma strict

var DOFSize:float = 5.0;
var focalPointDistance:float = 15.0;

var focusObjects:GameObject[];

function Start () {
	focusObjects = GameObject.FindGameObjectsWithTag ("focused");
}

function Update () {
	var focalPointPos = transform.position + Vector3(0,0,focalPointDistance);
	
	for (var focusObj in focusObjects){
		var dist = Mathf.Abs(focalPointPos.z - focusObj.transform.position.z);
		print(dist);
		focusObj.GetComponent.<Renderer>().material.SetFloat("_Blur",Mathf.Clamp((dist - DOFSize*0.5)*0.01,0,0.03));
	}
}