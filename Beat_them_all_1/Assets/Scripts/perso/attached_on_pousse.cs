using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached_on_pousse : MonoBehaviour {
    public AreaEffector2D area;
    public character_move perso;
    public SpriteRenderer Flop;
    public Transform appari_spot;
   void Start()
    {
         perso = GameObject.Find("perso 1").GetComponent<character_move>();
        // InvokeRepeating("position", 0, 0.1f);
        area = GetComponent<AreaEffector2D>();
        Flop= GetComponent<SpriteRenderer>();
        if (perso.facingRight)
        {
            
            Flop.flipX = false;
           // area.forceAngle = 0;
        }
        else
        {
            Flop.flipX = true;
            area.forceAngle = 180;
         
        }
    }
   /* void position()
    {
        transform.position = new Vector2(appari_spot.position.x, appari_spot.position.y);

    }*/

	}

