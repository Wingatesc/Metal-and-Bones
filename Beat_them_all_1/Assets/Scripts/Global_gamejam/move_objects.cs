using UnityEngine;
using System.Collections;

public class move_objects : MonoBehaviour {
    public GameObject[] wood;
    public GameObject[] metal;
    public bool wood_move=false;
    public bool metal_move=false;
    // Use this for initialization
    void Start () {
        wood = GameObject.FindGameObjectsWithTag("Wood");
        metal = GameObject.FindGameObjectsWithTag("Metal");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            wood_move=!wood_move;

        }
        
	}
}
