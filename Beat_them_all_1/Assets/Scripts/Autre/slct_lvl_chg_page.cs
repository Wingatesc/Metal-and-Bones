using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slct_lvl_chg_page : MonoBehaviour {
    public GameObject panel_showed;
    public GameObject panel_to_show;
	// Use this for initialization
	void Start () {
       // panel_to_hide.SetActive(false);
	}

    // Update is called once per frame
    public void OnClick()
    {
        panel_to_show.SetActive(true);
        panel_showed.SetActive(false);
    }
}
