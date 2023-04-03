using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //these are refferences
    public GameObject PlayerObj;
    public GameObject shieldtop;
    public GameObject shieldmid;
    public GameObject shieldbottom;
    private OrbitScript shieldMidOrbit;
    private OrbitScript shieldTopOrbit;
    private OrbitScript shieldBottomOrbit;
    private Renderer ShieldMidRend;
    private Renderer ShieldTopRend;
    private Renderer ShieldBottomRend;
    public GameObject PlayerSword;
    public CircleCollider2D MyCircleColider;
    private playerScript myPlayerScript;
    public GameObject Sword;
    private OrbitScript SwordOrbit;
    private Renderer SwordRend;
    //general variables
    public float ShieldRotation;
    public float Direction = 1;
    private float AngToPlayer = 0;
    // all this is for the defensive state
    public bool isVulnerable = false;
    public float shieldSpread = 0;
    private float ShieldOn = 0;
    private float PointHit = 0;
    private bool IsRecover = false;
    
    
//these variables generally for all acts.
    private float WindUp = 0;
    private float ActSpeed = 0;
    private float myTime = 0;
    private int NumInSeq = 1;
    private bool isAttacking = false;


//variables for dash
    private Vector2 VectToDash;
    private bool isDash;
    public float ForHowLong = 0;
    public Vector3 endPoint;
    private float SignX;
    private float SignY;
    private Vector3 RelativeEndPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        shieldMidOrbit = shieldmid.GetComponent<OrbitScript>();
        shieldTopOrbit = shieldtop.GetComponent<OrbitScript>();
        shieldBottomOrbit = shieldbottom.GetComponent<OrbitScript>();
        ShieldMidRend = shieldmid.GetComponent<SpriteRenderer>();
        ShieldTopRend = shieldtop.GetComponent<SpriteRenderer>();
        ShieldBottomRend = shieldbottom.GetComponent<SpriteRenderer>();
        myPlayerScript = PlayerObj.GetComponent<playerScript>();
        SwordOrbit = Sword.GetComponent<OrbitScript>();
        SwordRend = Sword.GetComponent<SpriteRenderer>();
        ShieldTopRend.enabled = false;
        ShieldMidRend.enabled = false;
        ShieldBottomRend.enabled = false;
        SwordRend.enabled = false;
        StartSeq();
    }
    // Update is called once per frame
    void Update()
    {
        AngToPlayer = +Mathf.PI * 0.5f + Mathf.Atan2(transform.position.y - PlayerObj.transform.position.y, transform.position.x - PlayerObj.transform.position.x);
        calcVulnerable();
        CalcDash();
    }
    void StartSeq()
    {
        Debug.Log(NumInSeq);
        StartVulnerable(1,1);
        Dash(5f,1,2);
        endSeq(3);
        
    }
    void calcVulnerable()
    {
        if (isVulnerable == true)
        {
            ShieldRotation = AngToPlayer;
            Direction = transform.position.x - PlayerObj.transform.position.x;
            Direction = Mathf.Abs(Direction) / Direction;
            shieldMidOrbit.Rotation = ShieldRotation;
            shieldTopOrbit.Rotation = ShieldRotation - shieldSpread * Direction;
            shieldBottomOrbit.Rotation = ShieldRotation + shieldSpread * Direction;
            
            
            if(MyCircleColider.IsTouching(PlayerSword.GetComponent<BoxCollider2D>()) == true && IsRecover == false && myPlayerScript.attackOn != 0)
            {
                PointHit = myPlayerScript.attackOn;
                if(PointHit == 1 && ShieldOn <= 1)
                {
                    Debug.Log("ya gottem");
                    IsRecover = true;
                }

                if(PointHit == 2 && ShieldOn <= 2 && ShieldOn > 1)
                {
                    Debug.Log("ya gottem");
                    IsRecover = true;
                }

                if(PointHit == 3 && ShieldOn > 2)
                {
                    Debug.Log("taco cats are funny... oh, also, you gottem");
                    IsRecover = true;
                }

                if(IsRecover == false)
                {
                    Debug.Log("in the words of one of my greatest friends, you failed");
                    IsRecover = true;
                }
                
                NewShieldState();
            }
            if(MyCircleColider.IsTouching(PlayerSword.GetComponent<BoxCollider2D>()) == false)
            {
                IsRecover = false;
            }
            myTime = myTime + ActSpeed * Time.deltaTime;
            if (myTime >= 1)
            {
                myTime = 0;
                isVulnerable = false;
                ShieldTopRend.enabled = false;
                ShieldMidRend.enabled = false;
                ShieldBottomRend.enabled = false;
                NumInSeq += 1;
                StartSeq();
            }
        }
    }
    void StartVulnerable(float TimeVulnerable, int PointInSeq)
    {
        if(PointInSeq == NumInSeq)
        {
            ActSpeed = TimeVulnerable;
            isVulnerable = true;
            NewShieldState();
        }
    }
    void NewShieldState()
    {
        ShieldOn = Random.Range(1, 4);
                if(ShieldOn <= 1f)
                {
                    ShieldTopRend.enabled = false;
                    ShieldMidRend.enabled = true;
                    ShieldBottomRend.enabled = true;
                }
                else if(ShieldOn <= 2f && ShieldOn >1f)
                {
                    ShieldTopRend.enabled = true;
                    ShieldMidRend.enabled = false;
                    ShieldBottomRend.enabled = true;
                }
                else if(ShieldOn > 2f)
                {
                    ShieldTopRend.enabled = true;
                    ShieldMidRend.enabled = true;
                    ShieldBottomRend.enabled = false;
                }
                //Debug.Log(ShieldOn);
    }
    void Dash(float speed, float charge, int PointInSeq)
    {
        if(PointInSeq == NumInSeq)
        {
            SwordRend.enabled = true;
            ActSpeed = speed;
            WindUp = charge;
            SwordOrbit.Radious = 1.5f;
            Direction = transform.position.x - PlayerObj.transform.position.x;
            Direction = Mathf.Abs(Direction)/Direction;
            SwordOrbit.Rotation = Mathf.PI *0.25f * Direction;
            isDash = true;
        }
        

    }
    void CalcDash()
    {
        if(isDash == true)
        {
            if(isAttacking == false)
            {
                Direction = transform.position.x - PlayerObj.transform.position.x;
                Direction = Mathf.Abs(Direction)/Direction;
                SwordOrbit.Rotation = Mathf.PI *0.25f * Direction;
                myTime = myTime + WindUp*Time.deltaTime;
                if(myTime >= 1)
                {
                    VectToDash = new Vector3(PlayerObj.transform.position.x - transform.position.x, PlayerObj.transform.position.y - transform.position.y, 0);
                    VectToDash = VectToDash / VectToDash.magnitude;
                    endPoint = PlayerObj.transform.position;
                    isAttacking = true;
                    myTime = 0;
                    SwordOrbit.Rotation = AngToPlayer;
                    Debug.Log(endPoint);
                    RelativeEndPoint = endPoint - transform.position;
                    SignY = Mathf.Abs(RelativeEndPoint.y)/RelativeEndPoint.y;
                    SignX = Mathf.Abs(RelativeEndPoint.x)/RelativeEndPoint.x;
                }
            }
            else
            {
                RelativeEndPoint = endPoint - transform.position;
                transform.Translate(VectToDash*ActSpeed*Time.deltaTime);
                if(Mathf.Abs(RelativeEndPoint.y)/RelativeEndPoint.y == -SignY  || Mathf.Abs(RelativeEndPoint.x)/RelativeEndPoint.x == -SignX)
                {
                    isDash = false;
                    SwordRend.enabled = false;
                    myTime = 0;
                    isAttacking = false;
                    NumInSeq += 1;
                    StartSeq();
                }
            }

        }
    }
    float Magnitude2(float side1, float side2)
    {
        return Mathf.Sqrt(Mathf.Pow(side1,2) + Mathf.Pow(side1,2));
    }
    void endSeq(int PointInSeq)
    {
        if(PointInSeq == NumInSeq)
        {
            NumInSeq = 1;
            Debug.Log("thiswas called");
            StartSeq();
        }
    }

}
