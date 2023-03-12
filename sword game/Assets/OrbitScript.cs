using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbitScript : MonoBehaviour
{
    public GameObject center;
    public float Rotation;
    public float Radious;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mathf.Tan(45));

    }
    // tacos are delicious
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Rotation)*Radious,Mathf.Sin(Rotation)*Radious,0) + center.transform.position;
         transform.eulerAngles = new Vector3(0,0,Rotation/Mathf.PI*180 - 90);
    }
}
