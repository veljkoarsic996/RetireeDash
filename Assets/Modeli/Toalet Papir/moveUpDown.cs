using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    public float maxHeight = 1.1f;
    public float minHeight = 0.9f;
    public float speed = 0.1f;
    Vector3 point;

    void Start()
    {
        point = new Vector3(0, -1, 0);
        Debug.Log(transform.position.x);
    }

     void Update()
    {
       
        transform.position += point * Time.deltaTime/5;
        if (transform.position.y >= maxHeight)
        {
            point = new Vector3(0, -1, 0);
        } else if (transform.position.y <= minHeight) {
            point = new Vector3(0, 1, 0);
        }
    }


}