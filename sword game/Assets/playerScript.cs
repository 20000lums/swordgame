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
    public float swordStartingPoint = 0;
    public float swordEndPoint = 0;
    public float swingSpeed = 0;
    private OrbitScript swordOrbit;
    public GameObject sword;
    private float attackOn = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        swordOrbit = sword.GetComponent<OrbitScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
            {
                myRigidBody.AddForce(Vector2.left*moveSpeed);
            direction = -1;
            }
        if (Input.GetKey(KeyCode.D) == true)
            {
                myRigidBody.AddForce(Vector2.right*moveSpeed);
            direction = 1;
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
        Debug.Log(timer);
            if (delay <= timer)
        {
         
            if (Input.GetKeyDown(KeyCode.J) == true)
            {
                attackOn = 1;
                 
                timer = 0;
            }
            else if (Input.GetKeyDown(KeyCode.I) == true)
            {
                attackOn = 2;
                timer = 0;
                swordRotation = swordStartingPoint;
            }
            else if (Input.GetKeyDown(KeyCode.K) == true)
            {
                attackOn = 3;
                timer = 0;
            }

        }
        if (attackOn == 2)
        {
            swordRotation = swingSpeed * Time.deltaTime;
            if (swordRotation >= swordEndPoint)
            {
                swordRotation = 0;
                attackOn = 0;
            }
        }
        swordOrbit.Rotation = swordRotation * direction;
    }
}
