using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stop_sound : MonoBehaviour {
   // public bool SoundOn;
    public GameObject Sound;
    public GameObject music;
    public GameObject MusiqueScript;
    public dontDestroy_load_sound didi;
    public float AudioSourceVolumeMax=0.12f;

    // Use this for initialization
    void Start () {
       // AudioSource jouerMusique;
        // InvokeRepeating("bool_switch", 1, 1);
        DontDestroyOnLoad(transform.gameObject);
      //  SoundOn = true;
         Sound = GameObject.Find("Son_2");
         music = GameObject.Find("Musique");
        MusiqueScript = GameObject.Find("Musique");
        didi = MusiqueScript.GetComponent<dontDestroy_load_sound>();
        if (didi.SoundOn)
        {
            Sound.SetActive(true);
        }
        else
        {
            //Sound.SetActive(false);
            StartCoroutine(LateCall());
        }
        }

    // Update is called once per frame
    public void OnMouseDown()
    {
        if (music != null && Sound != null)
        {
            if (didi.SoundOn)
            {
                Sound.SetActive(false);
                //music.SetActive(false);
                didi.jouerMusique.volume=0;
                didi.SoundOn = false;
                Debug.Log("music on");
            }
            else
            {
                Sound.SetActive(true);
               // music.SetActive(true);
                didi.jouerMusique.volume = AudioSourceVolumeMax;
                didi.SoundOn = true;
                Debug.Log("music off");
                didi.jouerMusique.Play();
            }
        }
    }
    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(2);

        Sound.SetActive(false);
        //Do Function here...
    }

}
