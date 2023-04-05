using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject flore;
    public Rigidbody2D myRigidBody;
    public CircleCollider2D myCircleCollider;
    public float jumpHeight;
    private float direction = 1;
    private float timer = 0;
    public float delay = 0;
    private float swordRotation = 0;
    private float swordLeingth = 0;
    public float swordStartingPoint = 0;
    public float swordEndPoint = 0;
    public float swingSpeed = 0;
    private OrbitScript swordOrbit;
    public GameObject sword;
    public float attackOn = 0;
    public float swordStartingPoint2 = 0;
    public float swordEndPoint2 = 0;
    public float Range = 0;
    public float stabSpeed = 0;
    public GameObject Enemy;
    private EnemyScript myEnemyScript;
    private SpriteRenderer Rend;
    private SpriteRenderer SwordRend;
    private float AngToEnemy = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        swordOrbit = sword.GetComponent<OrbitScript>();
        myEnemyScript = Enemy.GetComponent<EnemyScript>();
        Rend = GetComponent<SpriteRenderer>();
        SwordRend = sword.GetComponent<SpriteRenderer>();
        SwordRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - Enemy.transform.position.x != 0)
        {
            AngToEnemy = Mathf.Atan2(transform.position.y - Enemy.transform.position.y, transform.position.x - Enemy.transform.position.x);
        }
        else
        {
            if(transform.position.y - transform.position.y == 1)
            {
                AngToEnemy = Mathf.PI;
            }
            else
            {
                AngToEnemy = 0;
            }
        }
        if(myEnemyScript.isVulnerable == false)
        {
            if(Input.GetKey(KeyCode.A) == true)
            {
                direction = -1;
                Rend.flipX = false;
            }
            if(Input.GetKey(KeyCode.D) == true)
            {
                direction = 1;
                Rend.flipX = true;
            }
        }
        else
        {
            direction = transform.position.x - Enemy.transform.position.x;
            direction = Mathf.Abs(direction)/direction;
            if(direction == 1)
            {
                Rend.flipX = false;
            }
            else
            {
                Rend.flipX = true;
            }
        }
        
        if (Input.GetKey(KeyCode.A) == true)
            {
                myRigidBody.AddForce(Vector2.left*moveSpeed*Time.deltaTime);

            }
        if (Input.GetKey(KeyCode.D) == true)
            {
                myRigidBody.AddForce(Vector2.right*moveSpeed*Time.deltaTime);
            }
         if (Input.GetKeyDown(KeyCode.Space) == true && myCircleCollider.IsTouching(flore.GetComponent<BoxCollider2D>()) == true)
            {
               myRigidBody.AddForce(Vector2.up*jumpHeight);
            }

        Attack();
        
    }

    void Attack()
    {
        timer = timer + Time.deltaTime;
        //Debug.Log(timer);
            if (delay <= timer)
        {
         
            if (Input.GetKeyDown(KeyCode.J) == true)
            {
                attackOn = 2;
                timer = 0;
                swordRotation = .5f * Mathf.PI;
                SwordRend.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.I) == true)
            {
                attackOn = 1;
                timer = 0;
                swordLeingth = Range;
                swordRotation = swordStartingPoint;
                SwordRend.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.K) == true)
            {
                attackOn = 3;
                timer = 0;
                swordLeingth = Range;
                swordRotation = swordStartingPoint2;
                SwordRend.enabled = true;
            }

        }
        if (attackOn == 2)
        {
            swordLeingth = swordLeingth + stabSpeed * Time.deltaTime;
            if (swordLeingth >= Range)
            {
                swordLeingth = 0;
                attackOn = 0;
                swordRotation = 0;
                SwordRend.enabled = false;
            }
        }
        if (attackOn == 1)
        {
            swordRotation = swordRotation + swingSpeed * Time.deltaTime;
            if (swordRotation >= swordEndPoint)
            {
                swordRotation = 0;
                attackOn = 0;
                swordLeingth = 0;
                SwordRend.enabled = false;
            }
        }
        if (attackOn == 3)
        {
            swordRotation = swordRotation - swingSpeed * Time.deltaTime;
            if (swordRotation <= swordEndPoint2)
            {
                swordRotation = 0;
                attackOn = 0;
                swordLeingth = 0;
                SwordRend.enabled = false;
            }
        }
        // Debug.Log(swordRotation);
        if(myEnemyScript.isVulnerable == false)
        {
            swordOrbit.Rotation = -swordRotation * direction;
        }
        else
        {
            swordOrbit.Rotation = -swordRotation * -direction + AngToEnemy;
        }
        swordOrbit.Radious = swordLeingth;
    }
}
