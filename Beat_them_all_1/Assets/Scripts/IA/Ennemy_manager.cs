using UnityEngine;
using System.Collections;

public class Ennemy_manager : MonoBehaviour {
	public vie_player viePerso;
	public GameObject adversaire_1;
	public float frequ_apparition=5f;
	public Transform[] appari_spots;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Apparition", frequ_apparition, frequ_apparition);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void Apparition(){
		if (viePerso.barre.fillAmount <= 0) {
			return;
		}
		int SpawnPointIndex = Random.Range (0, appari_spots.Length);
		Instantiate(adversaire_1,appari_spots[SpawnPointIndex].position,appari_spots[SpawnPointIndex].rotation);
	}
}
