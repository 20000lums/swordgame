using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool isVulnerable = false;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        isVulnerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isVulnerable == true)
        {
            
        }
    }
}
