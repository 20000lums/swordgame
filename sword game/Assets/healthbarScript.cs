using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarScript : MonoBehaviour
{
    public GameObject player;
    private playerScript PlayerScript;
    private SpriteRenderer Sprite;

    public float OgPosition;
    public float OgSize;
    private float Num;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = player.GetComponent<playerScript>();
        Sprite = GetComponent<SpriteRenderer>();
        OgPosition = transform.position.x;
        OgSize = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        Num = 100 - PlayerScript.PlayerHealth;

        transform.position = new Vector3(OgPosition -  OgSize , transform.position.y, 0);
        transform.localScale = new Vector3(PlayerScript.PlayerHealth / 100 * OgSize,1,0);
    }
}
