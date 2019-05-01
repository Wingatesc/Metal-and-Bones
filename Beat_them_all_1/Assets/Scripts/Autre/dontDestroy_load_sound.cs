using UnityEngine;
using System.Collections;

public class dontDestroy_load_sound : MonoBehaviour {
    public bool SoundOn;
    public AudioSource jouerMusique;
    public static dontDestroy_load_sound instance = null;
    // Use this for initialization
    private void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
    }
    void Start () {

        DontDestroyOnLoad(transform.gameObject);
        SoundOn = true;
         jouerMusique = GetComponent<AudioSource>();
        if (jouerMusique.isPlaying == false && SoundOn)
        {
            jouerMusique.Play();
        }
    }
	
	// Update is called once per frame

}
