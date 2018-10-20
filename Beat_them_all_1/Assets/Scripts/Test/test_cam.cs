﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_cam : MonoBehaviour {

    public GameObject player;     
    private Vector3 offset;           
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void FixedUpfate()
    {
        gameObject.transform.position = new Vector3((Mathf.RoundToInt(gameObject.transform.position.x)),
        (Mathf.RoundToInt(gameObject.transform.position.y)),
        (Mathf.RoundToInt(gameObject.transform.position.z)));     //used to keep camera bounded to integers
    }
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
