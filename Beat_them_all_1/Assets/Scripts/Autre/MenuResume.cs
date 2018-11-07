using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResume : MonoBehaviour {
    //public GameObject leMenu;
    public Menu script;
    // Use this for initialization
    void Start () {
        GameObject menuu = GameObject.Find("Menu-script");
        script = menuu.GetComponent<Menu>();
    }
    public void OnClick()
    {
        script.open=(false);
        Debug.Log("click");
    }
}
