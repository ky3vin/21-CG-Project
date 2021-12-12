using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 40.0f;


    // Update is called once per frame
    private void Update()
    {
        Orbit_Rotation();
    }
    void Orbit_Rotation()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
        //transform.Rotate(Vector 3 EularAngle)
    }
}
