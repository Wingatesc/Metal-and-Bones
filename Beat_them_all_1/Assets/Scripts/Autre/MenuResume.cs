using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResume : MonoBehaviour {
    public GameObject leMenu;
    // Use this for initialization
    void Start () {
        GameObject menuu = GameObject.Find("Menu-script");
        leMenu = menuu.GetComponent<GameObject>();
    }
    public void OnClick()
    {
        leMenu.SetActive(false);
        Debug.Log("click");

    }
}
