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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
            {
                myRigidBody.AddForce(Vector2.left*moveSpeed);
            }
        if (Input.GetKey(KeyCode.D) == true)
            {
                myRigidBody.AddForce(Vector2.right*moveSpeed);
            }
            if (Input.GetKeyDown(KeyCode.Space) == true && myCircleCollider.IsTouching(flore.GetComponent<BoxCollider2D>()) == true)
            {
                myRigidBody.AddForce(Vector2.up*jumpHeight);
            }
        
    }
}
