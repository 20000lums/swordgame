using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool isVulnerable = false;
    private bool isHit = false;
    public GameObject PlayerObj;
    public GameObject shieldtop;
    public GameObject shieldmid;
    public GameObject shieldbottom;
    public float ShieldRotation;
    public float Direction = 1;
    public float shieldSpread = 0;
    private float AngToPlayer = 0;
    private OrbitScript shieldMidOrbit;
    private OrbitScript shieldTopOrbit;
    private OrbitScript shieldBottomOrbit;
    private Renderer ShieldMidRend;
    private Renderer ShieldTopRend;
    private Renderer ShieldBottomRend;
    private float ShieldOn = 0;
    // Start is called before the first frame update
    void Start()
    {
        isVulnerable = true;
        shieldMidOrbit = shieldmid.GetComponent<OrbitScript>();
        shieldTopOrbit = shieldtop.GetComponent<OrbitScript>();
        shieldBottomOrbit = shieldbottom.GetComponent<OrbitScript>();
        ShieldMidRend = shieldmid.GetComponent<SpriteRenderer>();
        ShieldTopRend = shieldtop.GetComponent<SpriteRenderer>();
        ShieldBottomRend = shieldbottom.GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        AngToPlayer = Mathf.Atan2(transform.position.y - PlayerObj.transform.position.y, transform.position.x - PlayerObj.transform.position.x);
        calcVulnerable();
    }
    void calcVulnerable()
    {
        if (isVulnerable == true)
        {
            ShieldRotation = AngToPlayer;
            Direction = Mathf.Abs(AngToPlayer) / AngToPlayer;
            shieldMidOrbit.Rotation = Mathf.PI *0.5f + ShieldRotation;
            shieldTopOrbit.Rotation = Mathf.PI * 0.5f + ShieldRotation + shieldSpread * Direction;
            shieldBottomOrbit.Rotation = Mathf.PI * 0.5f + ShieldRotation - shieldSpread * Direction;
            if(isHit == true)
            {
                ShieldOn = Random.Range(0, 3);
                if(ShieldOn >= 1f)
                {

                }
                else if(ShieldOn >= 2f)
                {

                }
                else if(ShieldOn >= 3f)
                {

                }
            }
        }
    }
}
