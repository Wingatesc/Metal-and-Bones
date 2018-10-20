using UnityEngine;
using System.Collections;

public class echap_menu : MonoBehaviour {

	public string levelname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Escape))
		{
			Application.LoadLevel (levelname);
		}
	}
	
}
