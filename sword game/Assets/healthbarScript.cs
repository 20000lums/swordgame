using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarScript : MonoBehaviour
{
    private SpriteRenderer Sprite;
    public float health = 100;
    private float OgPosition;
    private float OgSize;
    private float Num;
    public bool GoesLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        OgPosition = transform.position.x;
        OgSize = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        Num = 100 - health;
        Num = Num / 100;
        Debug.Log(Num);
        if (GoesLeft == true)
        {
            transform.position = new Vector3(OgPosition -  OgSize * Num / 2, transform.position.y, 0);
        } 
        else
        {
            transform.position = new Vector3(OgPosition +  OgSize * Num / 2, transform.position.y, 0);
        }
        Num = 1 - Num;
        transform.localScale = new Vector3(OgSize * Num,1,0);
    }
}
