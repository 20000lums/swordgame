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
    // Start is called before the first frame update
    void Start()
    {
        isVulnerable = true;
        shieldMidOrbit = shieldmid.GetComponent<OrbitScript>();
        shieldTopOrbit = shieldtop.GetComponent<OrbitScript>();
        shieldBottomOrbit = shieldbottom.GetComponent<OrbitScript>();
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
            shieldMidOrbit.Rotation = ShieldRotation;
            shieldTopOrbit.Rotation = ShieldRotation + shieldSpread * Direction;
            shieldBottomOrbit.Rotation = ShieldRotation - shieldSpread * Direction;
        }
    }
}
