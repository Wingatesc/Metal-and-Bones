﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar_int_positif : MonoBehaviour {
	public GameObject barre;
	public float dommage;
	void OnTriggerEnter(){
		barre.GetComponent<Scrollbar> ().size=barre.GetComponent<Scrollbar> ().size + dommage;
		if (barre.GetComponent<Scrollbar> ().size != 0) {
			Destroy (gameObject, 2);
		}

	}

}
