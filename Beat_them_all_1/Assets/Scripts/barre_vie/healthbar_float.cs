using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar_float : MonoBehaviour {
	public GameObject barre;
	public float dommage;
	public GameObject perso;

	/*void OnTriggerStay(Collider target){
		if (target.tag == "Player") {
			barre.GetComponent<Scrollbar> ().size -= dommage * Time.deltaTime;
		}
		Debug.Log ("vie goooooooone");
	}*/
	void FixedUpdate(){
		barre.GetComponent<Scrollbar> ().size -= dommage * Time.deltaTime;
	}
}
