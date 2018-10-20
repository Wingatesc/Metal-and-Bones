using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_telekinesie_on : MonoBehaviour {
    public Poing perso;
    public Image img;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (perso.timer_pousse >= perso.time_btw_pousse)
        {
           
            img.color= new Color(0.43f,0.93f,0.54f);
          
            

        }
        else
        {
            img.color = new Color(0.93f,0.43f,0.44f);
        }
	}
}
