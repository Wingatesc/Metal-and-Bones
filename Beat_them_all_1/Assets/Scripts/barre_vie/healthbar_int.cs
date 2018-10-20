using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar_int : MonoBehaviour {
	public GameObject barre;
	public float dommage;

	void OnTriggerEnter(){
		barre.GetComponent<Scrollbar> ().size=barre.GetComponent<Scrollbar> ().size + dommage;

	}
	void OnTriggerExit(){
		Destroy (gameObject);
		
	}
}
