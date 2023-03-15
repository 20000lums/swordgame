using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbitScript : MonoBehaviour
{
    public GameObject center;
    public float Rotation;
    public float Radious;
    private float RotationB;
    // Start is called before the first frame update
    void Start()
    {

    }
    // tacos are delicious
    // Update is called once per frame
    void Update()
    {
        RotationB = Rotation + 0.5f * Mathf.PI;
        transform.position = new Vector3(Mathf.Cos(RotationB)*Radious,Mathf.Sin(RotationB)*Radious,0) + center.transform.position;
         transform.eulerAngles = new Vector3(0,0,RotationB/Mathf.PI*180 - 90);
    }
}
