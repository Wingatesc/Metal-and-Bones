using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Super_techniques : MonoBehaviour {
    public float Ultra_power;
   // public SpriteRenderer rend;
    public Image rend;
    public Sprite zero;
    public Sprite un;
    public Sprite deux;
    public Sprite trois;
    public Sprite quatre;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Sprite", 0, 1);
	}
    void Sprite()
    {
        if (Ultra_power ==0) {
            rend.sprite = zero;
            
        }
        if (Ultra_power == 1)
        {
            rend.sprite = un;
        }
        if (Ultra_power == 2)
        {
            rend.sprite = deux;
        }
        if (Ultra_power == 3)
        {
            rend.sprite = trois;
        }
        if (Ultra_power == 4)
        {
            rend.sprite = quatre;
        }
        if (Ultra_power <0)
        {
            Ultra_power = 0;

        }
        if (Ultra_power > 4)
        {
            Ultra_power = 4;

        }

    }
}
