using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {
	public float lala;
	// Use this for initialization
	void Start () {
	
	}
	void rando(){
		lala = Random.Range (-10, 10);
		Debug.Log (lala);
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.C))
			rando ();
		
		//Random.seed = 50;
	}
}
