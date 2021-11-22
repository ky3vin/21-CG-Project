using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Track : MonoBehaviour
{
    public Transform target;

    public Transform tr;
    Vector3 m_Input;
    public float m_Speed = 5;

    void Start()
    {
        tr = GetComponent<Transform>();

        
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            m_Input.x = Input.GetAxis("Mouse X");
            m_Input.y = Input.GetAxis("Mouse Y");

            if (m_Input.magnitude != 0)
            {
                Quaternion q = target.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x + m_Input.y * m_Speed, q.eulerAngles.y + m_Input.x * m_Speed, q.eulerAngles.z);
                target.rotation = q;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector3(target.position.x - 0.52f, tr.position.y, target.position.z - 6.56f);

        tr.LookAt(target);
    }

    public void LateUpdate()
    {
        Rotate();

    }

}