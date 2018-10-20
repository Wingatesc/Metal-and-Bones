#pragma strict

var HorizontalMin: float  = -15;
var HorizontalMax: float  = 15;
var VerticalMin: int  = 0;
var VerticalMax: int  = 4;

var ScrollArea: int  = 25;
var ScrollSpeed: int  = 5;
var DragSpeed: int  = 50;

var ZoomSpeed: float  = 25;
var ZoomMin: float  = 0;
var ZoomMax: float  = 20;

var PanSpeed: int  = 50;
var PanAngleMin: int  = 0;
var PanAngleMax: int  = 80;

var manualCam = true;
		/*bool manualCam = true;

	void SetManualOn(){manualCam = true;}

	void SetManualOff(){manualCam = false;}*/
	
// Update is called once per frame
function Update(){

	if(manualCam){
		// Init camera translation for this frame.		
		var translation = Vector3.zero;

		// VerticalSpeed in or out
		var ZoomSpeedDelta = Input.GetAxis("Mouse ScrollWheel")*ZoomSpeed*Time.deltaTime;
		if (ZoomSpeedDelta!=0){
			translation -= Vector3.back * ZoomSpeed * ZoomSpeedDelta;		
		}

		// Start panning camera if VerticalSpeeding in close to the ground or if just VerticalSpeeding out.
		/*var pan = camera.transform.eulerAngles.z - VerticalSpeedDelta * PanSpeed;
		
		pan = Mathf.Clamp(pan, PanAngleMin, PanAngleMax);
		
		if (VerticalSpeedDelta < 0 || camera.transform.position.y < (VerticalMax / 2))
			
		{
			
			camera.transform.eulerAngles = new Vector3(pan, 0, 0);
			
		}*/

		// Move camera with arrow keys
		translation += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		// Move camera with mouse	
		if (Input.GetMouseButton(2)){ // MMB
			// Hold button and drag camera around
			translation -= new Vector3(Input.GetAxis("Mouse X") * DragSpeed * Time.deltaTime, Input.GetAxis("Mouse Y") * DragSpeed * Time.deltaTime, 0);
		}
		
		else{
			
			// Move camera if mouse pointer reaches screen borders
			if (Input.mousePosition.x < ScrollArea){
				translation += Vector3.right * -ScrollSpeed * Time.deltaTime;
			}

			if (Input.mousePosition.x >= Screen.width - ScrollArea){
				translation += Vector3.right * ScrollSpeed * Time.deltaTime;
			}

			
			
			if (Input.mousePosition.y < ScrollArea)
				
			{
				
				translation += Vector3.up * -ScrollSpeed * Time.deltaTime;
				
			}
			
			
			
			if (Input.mousePosition.y > Screen.height - ScrollArea)
				
			{
				
				translation += Vector3.up * ScrollSpeed * Time.deltaTime;
				
			}
			
		}
		
		
		
		// Keep camera within level and VerticalSpeed area
		
		var desiredPosition = GetComponent.<Camera>().transform.position + translation;
		
		if (desiredPosition.x < HorizontalMin || HorizontalMax < desiredPosition.x)
			
		{
			
			translation.x = 0;
			
		}
		
		if (desiredPosition.y < VerticalMin || VerticalMax < desiredPosition.y)
			
		{
			
			translation.y = 0;
			
		}
		
		if (desiredPosition.z < ZoomMin || ZoomMax < desiredPosition.z)
			
		{
			
			translation.z = 0;
			
		}
		
		
		
		// Finally move camera parallel to world axis
		
		GetComponent.<Camera>().transform.position += translation;
		
	}
}
