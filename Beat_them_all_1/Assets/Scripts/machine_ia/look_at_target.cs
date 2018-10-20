using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_target : MonoBehaviour {
    public Transform perso;
    private Quaternion OriginalRotation;
   // [SerializeField]
    private Vector3 rotationRange;
    public float min_rotation=0f;
    public float max_rotation=180f;
    public SpriteRenderer pivote;
    public Rigidbody2D rb;
    void Start()
    {  
        OriginalRotation = transform.localRotation;
        pivote = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pivote.flipX = false;
        GameObject player = GameObject.Find("perso 1");
        perso = player.transform;
    }
    // Update is called once per frame
    void Update () {
         transform.localRotation = OriginalRotation;
         Vector3 dir = perso.position - transform.position;
         float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
         zAngle = Mathf.Clamp(zAngle, min_rotation, max_rotation);
         transform.localRotation = OriginalRotation * Quaternion.Euler(0, 0, zAngle);
    }
}
