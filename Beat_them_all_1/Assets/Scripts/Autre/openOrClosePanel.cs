using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openOrClosePanel : MonoBehaviour {
    public bool open;
    public GameObject fenetre;
    public void OnClick()
    {
        if (open&&fenetre!=null)
        {
            fenetre.SetActive(true);
        }
        if (!open && fenetre != null) //when I want to close a panel
        {
             fenetre.SetActive(false);
        }
    }
}
