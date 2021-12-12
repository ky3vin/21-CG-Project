using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryEffects_Forest : MonoBehaviour
{
    public float rotateSpeed = 180.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}

