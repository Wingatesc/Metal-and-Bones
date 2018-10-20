using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class barre_de_vie_perso : MonoBehaviour {
	public GameObject barre;
	public GameObject sprite;
	public float dommages;
	public Color stade1;
	public Color stade2;
	public Color stade3;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {


		if (barre.GetComponent<Scrollbar> ().size > 0.7f) {
			sprite.GetComponent<Image> ().color = stade1;

		} else if (barre.GetComponent<Scrollbar> ().size > 0.3f && barre.GetComponent<Scrollbar> ().size < 0.7f) {
			sprite.GetComponent<Image> ().color = stade2;
		} else {
			sprite.GetComponent<Image> ().color = stade3;
		}

	}
}
