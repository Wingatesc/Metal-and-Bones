using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bolean_menu : MonoBehaviour {
	public bool open;
	public GameObject text;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			open=!open;
			
		}
		if (open) {
			text.SetActive (true);
		}
		else {
			text.SetActive (false);
		
		}
	}
}
