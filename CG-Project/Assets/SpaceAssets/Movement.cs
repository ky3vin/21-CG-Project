using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    float jAxis;

    Vector3 move;

    void Start()
    {

    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jAxis = Input.GetAxisRaw("Jump");

        move = new Vector3(hAxis, jAxis, vAxis).normalized;

        transform.position += move * speed * Time.deltaTime;

        transform.LookAt(transform.position + move);
    }
}

 
