using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletPapirAnimation : MonoBehaviour
{
    float speed = 30f; 


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed* Time.deltaTime);
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 10);

    }
}

