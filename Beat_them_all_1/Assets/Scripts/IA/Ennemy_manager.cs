using UnityEngine;
using System.Collections;

public class Ennemy_manager : MonoBehaviour {
	//public vie_player viePerso;
	public GameObject adversaire;
	public float frequ_apparition=5f;
    private bool timeToSpawn;
    //public Transform[] appari_spots;
    public Transform appari;
	void Start () {
		InvokeRepeating ("Apparition", 0, frequ_apparition);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&appari!=null)
        {
            timeToSpawn = true; 
        }
    }
    void Apparition(){
        /*if (viePerso.barre.fillAmount <= 0) {
			return;
		}
        int SpawnPointIndex = Random.Range (0, appari_spots.Length);
		Instantiate(adversaire_1,appari_spots[SpawnPointIndex].position,appari_spots[SpawnPointIndex].rotation);*/
        if (timeToSpawn)
        {
            Instantiate(adversaire, appari.position, appari.rotation);
            Destroy(gameObject);
        }
    }
}
