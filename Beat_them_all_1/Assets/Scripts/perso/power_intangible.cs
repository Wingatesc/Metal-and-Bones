using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_intangible : MonoBehaviour {
    public CapsuleCollider2D coll;
    public bool peut=true;
   
	// Use this for initialization
	void Start () {
        coll = GetComponent<CapsuleCollider2D>();
        InvokeRepeating("Power", 0, 0.05f);  
	}

    IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        coll.isTrigger = false;
        peut = true;
        StopCoroutine(time());
    }
    void Power()
    {
        if (Input.GetKeyDown(KeyCode.F)&&peut)
        {
            print("appuyé sur F");
            coll.isTrigger = true;
            StartCoroutine(time());
            peut = false;
        }
    }
 
}
