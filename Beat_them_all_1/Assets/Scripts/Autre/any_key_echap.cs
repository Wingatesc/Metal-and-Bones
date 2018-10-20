using UnityEngine;
using System.Collections;

public class any_key_echap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.Quit();
		}
	}
}
