using UnityEngine;
using System.Collections;

public class follow_character : MonoBehaviour {
	public float distance;
	public float distanceMax;
    public bool chase;
    public SpriteRenderer pivote;
	public Transform perso;
	public Transform mechant;
	public float speed;
    public Rigidbody2D rb;
    [SerializeField] private Vector3 rotationRange;
    private Quaternion OriginalRotation;
    public float speed_when_follow=2f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        pivote = GetComponent<SpriteRenderer>();
        OriginalRotation = transform.localRotation;
        pivote.flipX = false;
    }
	
	// Update is called once per frame
	void Update () { 
		distance = Vector2.Distance(perso.transform.position, mechant.transform.position);
      //  transform.right = perso.position - transform.position;
        transform.localRotation = OriginalRotation;
       Vector3 dir = perso.position - transform.position;
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
          zAngle = Mathf.Clamp(zAngle, -rotationRange.z * 0.5f, rotationRange.z * 0.5f);
           transform.localRotation =OriginalRotation* Quaternion.Euler(0, 0, zAngle);
      
        if (distance >= distanceMax) {
            // speed = speed_when_follow;
            //mechant.transform.Translate(Vector2.right * Time.deltaTime*speed);
            chase = true;
         } else {
           
            chase = false;
         }
        if (chase)
        {
           if (perso.position.x < mechant.position.x)
            {
             
                pivote.flipY = true;
                    mechant.transform.Translate(Vector2.right* Time.deltaTime * speed_when_follow);
             
            }
            else
            {
                pivote.flipY = false;
          
                  mechant.transform.Translate(Vector2.right* Time.deltaTime * speed_when_follow);
            }

        }
    }


}
